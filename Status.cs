using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class Destination
    {
        public Int64 System { get; set; }
        public int Body { get; set; }
        public string Name { get; set; }

        public string Name_Localised { get; set; }
    }

    public class Fuel
    {
        public double FuelMain { get; set; }
        public double FuelReservoir { get; set; }
    }

    public class Status
    {

        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public int Flags { get; set; }

        public bool Docked { get
            {
                return (Flags & 1) != 0;
            }
        }

        public bool Landed
        {
            get
            {
                return (Flags & 2) != 0;
            }
        }

        public bool LandingGearDown
        {
            get
            {
                return (Flags & 4) != 0;
            }
        }

        public bool ShieldsUp
        {
            get
            {
                return (Flags & 8) != 0;
            }
        }

        public bool SuperCruise
        {
            get
            {
                return (Flags & 16) != 0;
            }
        }

        public bool FlightAssistOff
        {
            get
            {
                return (Flags & 32) != 0;
            }
        }

        public bool HardPointsDeployed
        {
            get
            {
                return (Flags & 64) != 0;
            }
        }

        public bool InWing
        {
            get
            {
                return (Flags & 128) != 0;
            }
        }

        public bool LightsOn
        {
            get
            {
                Console.WriteLine(Flags & 256);
                return (Flags & 256) != 0;
            }
        }

        public bool CargoScoopDeployed
        {
            get
            {
                return (Flags & 512) != 0;
            }
        }

        public bool SilentRunning
        {
            get
            {
                return (Flags & 1024) != 0;
            }
        }

        public bool ScoopingFuel
        {
            get
            {
                return (Flags & 2048) != 0;
            }
        }

        public bool FSDMassLocked
        {
            get
            {
                return (Flags & 0x10000) != 0;
            }
        }

        public bool FSDCoolDown
        {
            get
            {
                return (Flags & 0x40000) != 0;
            }
        }

        public bool HUDInAnalisysMode
        {
            get
            {
                return (Flags & 0x08000000) != 0;
            }
        }

        public bool NightVision
        {
            get
            {
                return (Flags & 0x10000000) != 0;
            }
        }

        public bool IsLegal
        {
            get
            {
                return (LegalState == "Clean" || LegalState == "Speeding");
            }
        }

        public int Flags2 { get; set; }
        public List<int> Pips { get; set; }

        public int PipsSIS { get
            {
                if (this.Pips != null && this.Pips.Count >= 1)
                {
                    return this.Pips[0];
                }
                else return 0;
            } }

        public int PipsENG
        {
            get
            {
                if (this.Pips != null && this.Pips.Count >= 2)
                {
                    return this.Pips[1];
                }
                else return 0;
            }
        }

        public int PipsWEP
        {
            get
            {
                if (this.Pips != null && this.Pips.Count >= 3)
                {
                    return this.Pips[2];
                }
                else return 0;
            }
        }



        public int FireGroup { get; set; }
        public int GuiFocus { get; set; }
        public Fuel Fuel { get; set; }
        public double Cargo { get; set; }
        public string LegalState { get; set; }
        public Int64 Balance { get; set; }
        public Destination Destination { get; set; }

        public bool InSRV
        {
            get
            {
                return (Flags & 0x04000000) != 0;
            }
        }
    }

}

/*
 
Flags:

Bit	Value	Hex	Meaning
0	1	0000 0001	Docked, (on a landing pad)
1	2	0000 0002	Landed, (on planet surface)
2	4	0000 0004	Landing Gear Down
3	8	0000 0008	Shields Up
4	16	0000 0010	Supercruise
5	32	0000 0020	FlightAssist Off
6	64	0000 0040	Hardpoints Deployed
7	128	0000 0080	In Wing
8	256	0000 0100	LightsOn
9	512	0000 0200	Cargo Scoop Deployed
10	1024	0000 0400	Silent Running,
11	2048	0000 0800	Scooping Fuel
12	4096	0000 1000	Srv Handbrake
13	8192	0000 2000	Srv using Turret view
14	16384	0000 4000	Srv Turret retracted (close to ship)
15	32768	0000 8000	Srv DriveAssist
16	65536	0001 0000	Fsd MassLocked
17	131072	0002 0000	Fsd Charging
18	262144	0004 0000	Fsd Cooldown
19	524288	0008 0000	Low Fuel ( < 25% )
20	1048576	0010 0000	Over Heating ( > 100% )
21	2097152	0020 0000	Has Lat Int64
22	4194304	0040 0000	IsInDanger
23	8388608	0080 0000	Being Interdicted
24	16777216	0100 0000	In MainShip
25	33554432	0200 0000	In Fighter
26	67108864	0400 0000	In SRV
27	134217728	0800 0000	Hud in Analysis mode
28	268435456	1000 0000	Night Vision
29	536870912	2000 0000	Altitude from Average radius
30‭	1073741824‬	4000 0000	fsdJump
31	2147483648	8000 0000	srvHighBeam
Flags2 bits:

Bit	Value	Hex	Meaning
0	1	0001	OnFoot
1	2	0002	InTaxi (or dropship/shuttle)
2	4	0004	InMulticrew (ie in someone else's ship)
3	8	0008	OnFootInStation
4	16	0010	OnFootOnPlanet
5	32	0020	AimDownSight
6	64	0040	LowOxygen
7	128	0080	LowHealth
8	256	0100	Cold
9	512	0200	Hot
10	1024	0400	VeryCold
11	2048	0800	VeryHot
12	4096	1000	Glide Mode
13	8192	2000	OnFootInHangar
14	16384	4000	OnFootSocialSpace
15	32768	8000	OnFootExterior
16	65536	0001 0000	BreathableAtmosphere
17	131072	0002 0000	Telepresence Multicrew
18	262144	0004 0000	Physical Multicrew

 */ 