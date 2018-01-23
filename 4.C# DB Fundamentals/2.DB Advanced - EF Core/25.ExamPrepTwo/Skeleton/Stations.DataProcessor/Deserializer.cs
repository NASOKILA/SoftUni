namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using System.Text;
    using Newtonsoft.Json;
    using Stations.DataProcessor.Dto.Import;
    using System.Collections.Generic;
    using Stations.Models;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using Stations.DataProcessor.Dto.Import.Ticket;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
            var deseriaizedStations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            List<Station> validStations = new List<Station>();

            StringBuilder sb = new StringBuilder();

            foreach (var stationDto in deseriaizedStations)
            {

                //Ako go nqma ili duljinata na propertitata e nad 50 IMAME ANOTACII V DTOto
                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Ako ne e dadeno ime na Grada t.e. ako e null mu slagame imeto na stanciqta
                if (stationDto.Town == null)
                    stationDto.Town = stationDto.Name;


                bool AlreadyExists = validStations
                    .Any(s => s.Name == stationDto.Name);

                //Ako Veche sushtestvuva vus validStations

                if (AlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //Configurirahme go v automappera sega mojem da go polzvame
                Station station = Mapper.Map<Station>(stationDto);
                

                validStations.Add(station);
                sb.AppendLine(string.Format(SuccessMessage, stationDto.Name));

            }
            
            context.Stations.AddRange(validStations);
            context.SaveChanges();

            return sb.ToString();
		}
        
        public static string ImportClasses(StationsDbContext context, string jsonString)
		{
            var deseriaizedClasses = JsonConvert
                .DeserializeObject<SeatingClassDto[]>(jsonString);

            List<SeatingClass> validSeatingClass = new List<SeatingClass>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in deseriaizedClasses)
            {

                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                bool AlreadyExists = validSeatingClass
                    .Any(s => s.Name == dto.Name || s.Abbreviation == dto.Abbreviation);

                if (AlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Suzdavame si obekta s Automappera
                SeatingClass seatingClass = Mapper.Map<SeatingClass>(dto);
                
                validSeatingClass.Add(seatingClass);
                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
                
            }

           context.SeatingClasses.AddRange(validSeatingClass);
           context.SaveChanges();

            return sb.ToString();
        }

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{

            var deseriaizedTrains = JsonConvert
               .DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings()
               {
                    NullValueHandling = NullValueHandling.Ignore
               }); //mahame nulevite stoinosti

            List<Train> validTrains = new List<Train>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in deseriaizedTrains)
            {

                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Proverqvame dali vlaka sushtestvuva
                bool trainAlreadyExists = validTrains.Any(t => t.TrainNumber == dto.TrainNumber);
                if (trainAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //Proverqvame dali mestata sa validni
                bool seatsAreValid = dto.Seats.All(IsValid);

                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //proverqvame dali vseki edin ot tezi klasove go ima veche v bazata
                bool seatingClassesAreValid = dto.Seats
                    .All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name 
                    && sc.Abbreviation == s.Abbreviation));

                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                

                //Vzimame si tiput kato go parsvame kum enum
                var type = Enum.Parse<TrainType>(dto.Type);

                //Vzimame si sedalkite ot DTOto i gi transformirame na TrainSeat
                //Kato gi durpame ot samata baza
                var trainSeats = dto.Seats.Select(s => new TrainSeat
                {
                    //Durpame gi ot bazata
                    SeatingClass = context.SeatingClasses
                    .SingleOrDefault(sc => sc.Name == s.Name
                        && sc.Abbreviation == s.Abbreviation),

                    Quantity = s.Quantity.Value  //Slagame mu Value zashtoto e nullable

                }).ToArray();


                //Suzdavame si vlaka BEZ Automappera
                Train train = new Train
                {
                    TrainNumber = dto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);
                sb.AppendLine(string.Format(SuccessMessage, dto.TrainNumber));

            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            return sb.ToString();
            
        }
        
        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var deserializedTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();
            var validTrips = new List<Trip>();

            foreach (var tripDto in deserializedTrips)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = context.Trains.SingleOrDefault(t => t.TrainNumber == tripDto.Train);

                var originStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.OriginStation);

                var destinationStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.DestinationStation);

                if (train == null || originStation == null || destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                TimeSpan timeDifference;
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                if (departureTime > arrivalTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var status = Enum.Parse<TripStatus>(tripDto.Status);

                var trip = new Trip
                {
                    Train = train,
                    OriginStation = originStation,
                    DestinationStation = destinationStation,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Status = status,
                    TimeDifference = timeDifference
                };

                validTrips.Add(trip);
                sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }
        
        public static string ImportCards(StationsDbContext context, string xmlString)
		{

            //Taka go parsvame
            //Pravim si purvo serializer
            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));

            //i si deserializirame cartite kato gi parsvame kum masiv ot DTO to CardDto
            var deserializedCards = (CardDto[]) serializer
                .Deserialize(new MemoryStream(Encoding.UTF8
                .GetBytes(xmlString)));



            StringBuilder sb = new StringBuilder();

            List<CustomerCard> validCards = new List<CustomerCard>();
            
            foreach (var cardDto in deserializedCards)
            {
                if (!IsValid(cardDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                //Vzimame si stringa
                var type = Enum.Parse<CardType>(cardDto.CardType);

                if (cardDto.Name.Length > 128 || cardDto.Name == null || cardDto.Age < 0 || cardDto.Age > 128)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }



                var customerCard = new CustomerCard()
                {
                    Age = cardDto.Age,
                    Name = cardDto.Name,
                    Type = type
                };

                validCards.Add(customerCard);
                sb.AppendLine(string.Format(SuccessMessage, cardDto.Name));

            }

            context.Cards.AddRange(validCards);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validTickets = new List<Ticket>();
            foreach (var ticketDto in deserializedTickets)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime =
                    DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                                              t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                                              t.DepartureTime == departureTime);
                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
                var quantity = int.Parse(ticketDto.Seat.Substring(2));

                var seat = ticketDto.Seat;

                var ticket = new Ticket
                {
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticketDto.Price,
                    SeatingPlace = seat
                };

                validTickets.Add(ticket);
                sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.",
                    trip.OriginStation.Name,
                    trip.DestinationStation.Name,
                    trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }


        //Shte ni validira vsichki propertita spored anotaciite
        private static bool IsValid(object obj)
        {
            //Ima validator koito proverqva dali propertito shte se schupi 
            //Imame anotazii na propertito
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            //Tuk shte si zapisvame rezultatite
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}






