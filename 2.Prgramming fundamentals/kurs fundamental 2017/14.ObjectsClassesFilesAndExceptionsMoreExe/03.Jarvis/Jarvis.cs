using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Jarvis
{
    class Arm
    {
        public long EnergyConsumption { get; set; }
        public int ArmReachDistance { get; set; }
        public int CountOfFingers { get; set; }
    }

    class Leg
    {
        public long EnergyConsumption { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }

    class Torso
    {
        public long EnergyConsumption { get; set; }
        public double ProcessorSizeInCentimeters { get; set; }
        public string HousingMaterial { get; set; }
    }

    class Head
    {
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string SkinMaterial { get; set; }
    }


    class Jarvis
    {
        static void Main(string[] args)
        {
            ulong maxCapacity = ulong.Parse(Console.ReadLine());

            string[] data = Console.ReadLine()
                .Split(' ')
                .ToArray();

            bool containHead = false;
            bool containTorso = false;
            int armCount = 0;
            int legCount = 0;

            List<Head> heads = new List<Head>();
            List<Torso> torsoes = new List<Torso>();
            List<Arm> arms = new List<Arm>();
            List<Leg> legs = new List<Leg>();

            while (data[0] != "Assemble!")
            {
                string component = data[0];
                int consumedEnergy = int.Parse(data[1]);

                if (component == "Head")
                {
                    Head head = new Head()
                    {
                        EnergyConsumption = consumedEnergy,
                        IQ = int.Parse(data[2]),
                        SkinMaterial = data[3]
                    };
                    containHead = true;
                    heads.Add(head);
                }
                else if (component == "Torso")
                {
                    Torso torso = new Torso()
                    {
                        EnergyConsumption = consumedEnergy,
                        ProcessorSizeInCentimeters = int.Parse(data[2]),
                        HousingMaterial = data[3]
                    };
                    containTorso = true;
                    torsoes.Add(torso);
                }
                else if (component == "Arm")
                {
                    Arm arm = new Arm()
                    {
                        EnergyConsumption = consumedEnergy,
                        ArmReachDistance = int.Parse(data[2]),
                        CountOfFingers = int.Parse(data[3]),
                    };
                    armCount++;
                    arms.Add(arm);
                }
                else if (component == "Leg")
                {
                    Leg leg = new Leg()
                    {
                        EnergyConsumption = consumedEnergy,
                        Strength = int.Parse(data[2]),
                        Speed = int.Parse(data[3])
                    };

                    legCount++;
                    legs.Add(leg);
                }

                maxCapacity -= (ulong)consumedEnergy;

                if (maxCapacity <= 0)
                {
                    Console.WriteLine("We need more power!");
                    return;
                }



                data = Console.ReadLine()
                .Split(' ')
                .ToArray();
            }

            if (legCount < 2 || armCount < 2 || containHead == false || containTorso == false)
            {
                Console.WriteLine("We need more parts!");
                return;
            }

            Head headOfRobot = heads.OrderBy(e => e.EnergyConsumption).FirstOrDefault();
            Torso torsoOfRobot = torsoes.OrderBy(e => e.EnergyConsumption).FirstOrDefault();
            List<Arm> armsOfRobot = arms.OrderBy(e => e.EnergyConsumption).Take(2).ToList();
            List<Leg> legsOfRobot = legs.OrderBy(e => e.EnergyConsumption).Take(2).ToList();

            PrintResult(headOfRobot, torsoOfRobot, armsOfRobot, legsOfRobot);
        }

        private static void PrintResult(Head headOfRobot, Torso torsoOfRobot, List<Arm> armsOfRobot, List<Leg> legsOfRobot)
        {

            Console.WriteLine("Jarvis:");

            Console.WriteLine("#Head:");
            Console.WriteLine($"###Energy consumption: {headOfRobot.EnergyConsumption}");
            Console.WriteLine($"###IQ: {headOfRobot.IQ}");
            Console.WriteLine($"###Skin material: {headOfRobot.SkinMaterial}");

            Console.WriteLine("#Torso:");
            Console.WriteLine($"###Energy consumption: {torsoOfRobot.EnergyConsumption}");
            Console.WriteLine($"###Processor size: {torsoOfRobot.ProcessorSizeInCentimeters:F1}");
            Console.WriteLine($"###Corpus material: {torsoOfRobot.HousingMaterial}");

            Arm firstArm = armsOfRobot.First();
            Arm secondArm = armsOfRobot.Last();

            Console.WriteLine("#Arm:");
            Console.WriteLine($"###Energy consumption: {firstArm.EnergyConsumption}");
            Console.WriteLine($"###Reach: {firstArm.ArmReachDistance}");
            Console.WriteLine($"###Fingers: {firstArm.CountOfFingers}");

            Console.WriteLine("#Arm:");
            Console.WriteLine($"###Energy consumption: {secondArm.EnergyConsumption}");
            Console.WriteLine($"###Reach: {secondArm.ArmReachDistance}");
            Console.WriteLine($"###Fingers: {secondArm.CountOfFingers}");

            Leg firstLeg = legsOfRobot.First();
            Leg secondLeg = legsOfRobot.Last();

            Console.WriteLine("#Leg:");
            Console.WriteLine($"###Energy consumption: {firstLeg.EnergyConsumption}");
            Console.WriteLine($"###Strength: {firstLeg.Strength}");
            Console.WriteLine($"###Speed: {firstLeg.Speed}");

            Console.WriteLine("#Leg:");
            Console.WriteLine($"###Energy consumption: {secondLeg.EnergyConsumption}");
            Console.WriteLine($"###Strength: {secondLeg.Strength}");
            Console.WriteLine($"###Speed: {secondLeg.Speed}");

        }
    }
}
