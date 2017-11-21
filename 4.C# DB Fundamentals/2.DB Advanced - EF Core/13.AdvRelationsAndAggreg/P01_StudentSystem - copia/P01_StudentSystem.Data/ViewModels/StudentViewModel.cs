namespace P01_StudentSystem.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentViewModel
    {

        //TOVA E ViewModel ZA Student I DIREKTNO NI OTPECHATVA REZULTAT !!!


        public StudentViewModel()
        {

        }

        public StudentViewModel(string name, string phoneNumber, DateTime registrateOn)
        {
            this.studentName = name;
            this.studentPhoneNumber = phoneNumber;
            this.studentRegistration = registrateOn;
        }

        public string studentName { get; set; }

        public string studentPhoneNumber { get; set; }

        public DateTime studentRegistration { get; set; }


        //PREZAPISVAME METODA ToString() ZA DA MOJEM Da SI PRINTIRAME SELEKTIRANOTO.

        public override string ToString()
        {
            return $"Name: {studentName}  /  Phone: {studentPhoneNumber}  /  Registration: {studentRegistration}";
        }

    }
}
