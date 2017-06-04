using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());

            int dayPhotoWasTaken = int.Parse(Console.ReadLine());
            int monthPhotoWasTaken = int.Parse(Console.ReadLine());
            int yearPhotoWasTaken = int.Parse(Console.ReadLine());

            int hourPhowoWasTaken = int.Parse(Console.ReadLine());
            int minutePhowoWasTaken = int.Parse(Console.ReadLine());

            int photoSizeInBytes = int.Parse(Console.ReadLine());

            int photoWidthResolutionInPixels = int.Parse(Console.ReadLine());
            int photoHeigthResolutionInPixels = int.Parse(Console.ReadLine());

            double photoSizeInMb = photoSizeInBytes;

            string orientation = string.Empty;

            if (photoWidthResolutionInPixels == photoHeigthResolutionInPixels)
                orientation = "square";
            else if (photoWidthResolutionInPixels < photoHeigthResolutionInPixels)
                orientation = "portrait";
            else
                orientation = "landscape";

            Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
            Console.WriteLine($"Date Taken: {dayPhotoWasTaken:D2}/{monthPhotoWasTaken:D2}/{yearPhotoWasTaken:D4} {hourPhowoWasTaken:D2}:{minutePhowoWasTaken:D2}");

            if (photoSizeInBytes > 2000 && photoSizeInBytes < 999999)
                Console.WriteLine($"Size: {photoSizeInMb / 1000}KB");
            else if (photoSizeInBytes < 2000)
                Console.WriteLine($"Size: {photoSizeInMb}B");
            else
                Console.WriteLine($"Size: {photoSizeInMb / 1000000.0}MB");    

            Console.WriteLine($"Resolution: {photoWidthResolutionInPixels}x{photoHeigthResolutionInPixels} ({orientation})");

        }
    }
}
