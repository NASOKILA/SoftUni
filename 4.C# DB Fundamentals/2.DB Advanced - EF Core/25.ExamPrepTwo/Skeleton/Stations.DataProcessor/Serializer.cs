using System;
using Stations.Data;
using Newtonsoft.Json;
using System.Linq;
using Stations.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Stations.DataProcessor
{
	public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            

            DateTime date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            var trains = context.Trains
                .Include(t => t.Trips)
                .Where(t => t.TrainNumber.Length < 10 
                    && t.Trips.Any(tt => tt.Status == TripStatus.Delayed 
                    && tt.DepartureTime <= date))
                .Select(t => new {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.Trips.Where(tt => tt.Status == TripStatus.Delayed).Count(),
                    MaxDelayedTime = t.Trips.Where(tt => tt.Status == TripStatus.Delayed).Max(ti => ti.TimeDifference)
                })
                .OrderByDescending(w => w.DelayedTimes)
                .ThenByDescending(w => w.MaxDelayedTime)
                .ThenBy(w => w.TrainNumber)
                .ToArray();


            var trainsToExport = JsonConvert.SerializeObject(trains, Formatting.Indented);
            return trainsToExport;
        }

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            

            Ticket[] cards = context.Tickets
                .Include(c => c.CustomerCard)
                .Include(t => t.Trip).ThenInclude(t => t.DestinationStation)
                .Include(t => t.Trip).ThenInclude(t => t.OriginStation)
                .Where(t => t.CustomerCard.Type == (CardType)Enum.Parse(typeof(CardType), cardType))
                .OrderBy(t => t.CustomerCard.Name)
                .ToArray();

            XDocument xDoc = new XDocument();

            List<Ticket> uniqueCards = new List<Ticket>();
            List<string> cardsNames = new List<string>();

            foreach (var c in cards)
            {
                if (!cardsNames.Contains(c.CustomerCard.Name))
                {
                    cardsNames.Add(c.CustomerCard.Name);
                    uniqueCards.Add(c);
                }
            }

            XElement cardsElem = new XElement("Cards");

            //obhojdame kartite
            foreach (var card in uniqueCards.Select(c => c.CustomerCard))
            {

                XAttribute nameAttr = new XAttribute("name", card.Name);
                XAttribute typeAttr = new XAttribute("type", card.Type);

                XElement cardElem = new XElement("Card", nameAttr, typeAttr);


                XElement tickets = new XElement("Tickets");
                cardElem.Add(tickets);
                foreach (var t in card.BoughtTickets)
                {

                    XElement originStation = new XElement("OriginStation", t.Trip.OriginStation.Name);
                    XElement destinationStation = new XElement("DestinationStation", t.Trip.DestinationStation.Name);
                    XElement departureTime = new XElement("DepartureTime", t.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm"));


                    XElement ticketElem = new XElement("Ticket", originStation, destinationStation, departureTime);

                    tickets.Add(ticketElem);
                }


                cardsElem.Add(cardElem);
            }

            xDoc.Add(cardsElem);
            
            return xDoc.ToString();

        }
	}
}