namespace USParks.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<USParks.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "USParks.Data.ApplicationDbContext";
        }
        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }
        protected override void Seed(USParks.Data.ApplicationDbContext context)
        {
            context.Parks.AddOrUpdate(x => x.ParkId,
                new Park()
                {
                    ParkId = 1,
                    Name = "Yellowstone",
                    parkType = Park.ParkType.National,
                    Description = "Yellowstone National Park is a nearly 3,500-sq.-mile wilderness recreation area atop a volcanic hot spot. Mostly in Wyoming," +
                    " the park spreads into parts of Montana and Idaho too. Yellowstone features dramatic canyons, alpine rivers, lush forests, hot springs and" +
                    " gushing geysers, including its most famous, Old Faithful. It's also home to hundreds of animal species, including bears, wolves, bison, elk and antelope.",
                    Location = "Wyoming/Montana/Idaho",
                    Size = 3471,
                    YearlyVisitors = 4860000,
                    Image = File.ReadAllBytes("../../Images/yellowstone.jfif")
                },
                new Park()
                {
                    ParkId = 2,
                    Name = "Grand Caynon",
                    parkType = Park.ParkType.National,
                    Description = "Grand Canyon National Park, in Arizona, is home to much of the immense Grand Canyon," +
                    " with its layered bands of red rock revealing millions of years of geological history." +
                    " Viewpoints include Mather Point, Yavapai Observation Station and architect Mary Colter’s Lookout Studio and her Desert View Watchtower." +
                    " Lipan Point, with wide views of the canyon and Colorado River, is a popular, especially at sunrise and sunset.",
                    Location = "Arizona",
                    Size = 1902,
                    YearlyVisitors = 5900000,
                    Image = ReadFile("../../Images/grandcaynon.jpg")
                },
                new Park()
                {
                    ParkId = 3,
                    Name = "Grand Teton",
                    parkType = Park.ParkType.National,
                    Description = "Grand Teton National Park is an American national park in northwestern Wyoming. At approximately 310,000 acres (1,300 km2)," +
                    " the park includes the major peaks of the 40-mile-long (64 km) Teton Range as well as most of the northern sections of the valley known as Jackson Hole.",
                    Location = "Wyoming",
                    Size = 485,
                    YearlyVisitors = 3890000,
                    Image = ReadFile("../../Images/grandteton.jpg")
                },
                new Park()
                {
                    ParkId = 4,
                    Name = "Turkey Run",
                    parkType = Park.ParkType.State,
                    Description = "Deep canyons nestled in the shadows of sandstone cliffs and peaceful hemlock groves harbor some of the most ruggedly beautiful hiking trails in the state." +
                    " Trails are open from dawn to dusk. To get to many hiking trails you need to cross the suspension bridge over Sugar Creek.",
                    Location = "Indiana",
                    Size = 4,
                    YearlyVisitors = 1000000,
                    Image = ReadFile("../../Images/turkeyrun.jpg")
                },
                new Park()
                {
                    ParkId = 5,
                    Name = "Indiana Dunes",
                    parkType = Park.ParkType.National,
                    Description = "Indiana Dunes National Park is a United States national park located in northwestern Indiana managed by the National Park Service." +
                    " It was authorized by Congress in 1966 as the Indiana Dunes National Lakeshore and was redesignated as the nation's 61st national park on February 15, 2019.",
                    Location = "Indiana",
                    Size = 24,
                    YearlyVisitors = 3180000,
                    Image = ReadFile("../../Images/indianadunes.jpg")
                },
                new Park()
                {
                    ParkId = 6,
                    Name = "Isle Royale",
                    parkType = Park.ParkType.National,
                    Description = "Isle Royale National Park is a remote island cluster in Lake Superior, near Michigan’s border with Canada." +
                    " It’s a car-free wilderness of forests, lakes and waterways, where moose and wolves roam. The Greenstone Ridge Trail links the Windigo Harbor in the west and Rock Harbor in the east." +
                    " The 19th-century Rock Harbor Lighthouse has a small museum. Dive sites in the lake include several shipwrecks.",
                    Location = "Michigan",
                    Size = 893,
                    YearlyVisitors = 18216,
                    Image = ReadFile("../../Images/isleroyal.jpg")
                },
                new Park()
                {
                    ParkId = 7,
                    Name = "Yosemite",
                    parkType = Park.ParkType.National,
                    Description = "Yosemite National Park is in California’s Sierra Nevada mountains. It’s famed for its giant, ancient sequoia trees, and for Tunnel View," +
                    " the iconic vista of towering Bridalveil Fall and the granite cliffs of El Capitan and Half Dome. In Yosemite Village are shops, restaurants, lodging," +
                    " the Yosemite Museum and the Ansel Adams Gallery, with prints of the photographer’s renowned black-and-white landscapes of the area.",
                    Location = "California",
                    Size = 1169,
                    YearlyVisitors = 4200000,
                    Image = ReadFile("../../Images/Yosemite.jpg")
                },
                new Park()
                {
                    ParkId = 8,
                    Name = "Glacier",
                    parkType = Park.ParkType.National,
                    Description = "Glacier National Park is a 1,583-sq.-mi. wilderness area in Montana's Rocky Mountains, with glacier-carved peaks and valleys running to the Canadian border." +
                    " It's crossed by the mountainous Going-to-the-Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake." +
                    " Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.",
                    Location = "Montana",
                    Size = 1583,
                    YearlyVisitors = 3000000,
                    Image = ReadFile("../../Images/Glacier.jpg")
                },
                new Park()
                {
                    ParkId = 9,
                    Name = "Ichetucknee Springs",
                    parkType = Park.ParkType.State,
                    Description = "Although well-known for its warm weather tubing, the 2,669-acre Ichetucknee Springs State Park is also a wildlife haven, where beaver, otter, gar, softshell turtle" +
                    ", wild turkey, wood duck and limpkin all find a home. The main draw is the park’s eight major crystal-clear springs that join to create the 6-mile Ichetucknee River.",
                    Location = "Florida",
                    Size = 3,
                    YearlyVisitors = 200000,
                    Image = ReadFile("../../Images/IchetuckneeSprings.jfif")
                },
                new Park()
                {
                    ParkId = 10,
                    Name = "Waiʻānapanapa",
                    parkType = Park.ParkType.State,
                    Description = "Remote, wild, volcanic coastline offering solitude and respite from urban life. Lodging, camping, picnicking, shore fishing and hardy family hiking along an" +
                    " ancient Hawaiian coastal trail which leads to Hana. Excellent opportunity to view a seabird colony and natural stone arch. Other features include native hala forest," +
                    " heiau (religious temple), sea stacks, blow holes and small black sand beach.",
                    Location = "Hawaii",
                    Size = 1,
                    YearlyVisitors = 180000,
                    Image = ReadFile("../../Images/Waianapanapa.jpeg")
                }
                );

            context.Attractions.AddOrUpdate(x => x.AttractionId,
                new Attraction()
                {
                    AttractionId = 1,
                    Name = "Old Faithful",
                    Description = "Old Faithful is a cone geyser in Yellowstone National Park in Wyoming, United States." +
                    " It was named in 1870 during the Washburn–Langford–Doane Expedition and was the first geyser in the park to be named." +
                    " It is a highly predictable geothermal feature and has erupted every 44 minutes to two hours since 2000.",
                    ParkId = 1,
                    Image = ReadFile("../../Images/OldFaithful.jpg")
                },
                new Attraction()
                {
                    AttractionId = 2,
                    Name = "Mather Point",
                    Description = "Scenic viewpoint along South Rim, popular for its canyon vistas & proximity to the visitor center.",
                    ParkId = 2,
                    Image = ReadFile("../../Images/MatherPoint.jpg")

                },
                new Attraction()
                {
                    AttractionId = 3,
                    Name = "Yavapai Observation Station",
                    Description = "Educational museum on the South Rim offering a topographic relief model of the Grand Canyon.",
                    ParkId = 2,
                    Image = ReadFile("../../Images/YavapaiObservationStation.jpg")
                },
                new Attraction()
                {
                    AttractionId = 4,
                    Name ="Hole in the Wall",
                    Description = "Hole-in-the Wall Falls is an overfalls in Montana and has an elevation of 6,257 feet." +
                    " Hole-in-the Wall Falls is situated east of Boulder Glacier, and east of Boulder Pass.",
                    ParkId = 8,
                    Image = ReadFile("../../Images/HoleInTheWall.jpg")
                },
                new Attraction()
                {
                    AttractionId = 5,
                    Name = "El Capitan",
                    Description = "El Capitan’s iconic granite walls dominate the west end of Yosemite Valley. At more than" +
                    " 3,000 feet (900+ m) above the valley floor, it is 2.5 times as tall as the Empire State Building, or more" +
                    " than 3 times as high as the tip of the Eiffel Tower. Coming around the corner and having El Capitan suddenly" +
                    " fill your field of vision sometimes moves people to tears. It is a beacon for visitors, a muse for photographers" +
                    " and one of the world’s ultimate challenges for climbers.",
                    ParkId = 7,
                    Image = ReadFile("../../Images/ElCapitan.jpg")
                },
                new Attraction()
                {
                    AttractionId = 6,
                    Name = "Mariposa Grove of Giant Sequoias",
                    Description = "The Mariposa Grove of Giant Sequoia Trees, near Yosemite’s south entrance, contains about 500" +
                    " mature giant sequoia trees, perhaps the largest living things on Earth. The oldest Yosemite giant sequoia" +
                    " may exceed 3,000 years in age!  Among the most popular specimens in the grove is the Fallen Monarch which" +
                    " is made famous for an 1899 photograph of U.S. Cavalry officers on their horses up on top.",
                    ParkId = 7,
                    Image = ReadFile("../../Images/MariposaGroveofGiantSequoias.jpg")
                },
                new Attraction()
                {
                    AttractionId = 7,
                    Name = "Black Sand Beach Overlook",
                    Description = "After you park, you’ll see a sidewalk that will take you to the Waianapanapa black sand beach overlook." +
                    " This will be your first glimpse of the black sand beach – and it’s a view of Pailoa Bay from above!",
                    ParkId = 10,
                    Image = ReadFile("../../Images/BeachOverlook.jpeg")
                },
                new Attraction()
                {
                    AttractionId = 8,
                    Name = "Menagerie Island Light",
                    Description = "The Isle Royale Light stands on long, rocky Menagerie Island via Isle Royale's south shore at the entry" +
                    " to Siskiwit Bay. Reachable only by private boat, it features a 61-foot double-walled octagonal sandstone tower," +
                    " with a black lantern and gallery. It was completed and operative in 1875, and automated in 1913. The original Fourth" +
                    " Order Fresnel lens and subsequent light systems have been replaced with a 12-volt solar power 300 mm Tidelands Signal" +
                    " Acrylic Optic, which sends its beam out 10 miles.",
                    ParkId = 6,
                    Image = ReadFile("../../Images/MenagerieIslandLight.jpg")
                },
                new Attraction()
                {
                    AttractionId = 9,
                    Name = "Scoville Point",
                    Description = "This figure eight shaped trail offers the experience of a primarily wooded setting on the Tobin Harbor side," +
                    " and a rocky, exposed setting on the Rock Harbor side. At the end of the trail, both paths converge for the last half mile" +
                    " to ascend the rocky face of Scoville Point. Two return loops alow great versatility regarding the length and duration.",
                    ParkId = 6,
                    Image = ReadFile("../../Images/ScovillePoint.jfif")
                },
                new Attraction()
                {
                    AttractionId = 10,
                    Name = "Turkey Run Nature Center",
                    Description = "The Turkey Run State Park Nature Center offers interpretive naturalist services all year long." +
                    " Scheduled programs include hikes, planetarium programs, history talks, a junior naturalist program, and evening programs." +
                    " Special groups wishing programs just for their group should call in advance for this free service." +
                    " Inquire at the Nature Center, Inn or Park Office.",
                    ParkId = 4,
                    Image = ReadFile("../../Images/TurkeyRunCenter.jpg")
                }
                );

            context.Nature.AddOrUpdate(x => x.NatureId,
                new Nature()
                {
                    NatureId = 1,
                    Name = "Black Bear",
                    Description = "The American black bear, or simply black bear, is a medium-sized bear endemic to North America." +
                    " It is the continent's smallest and most widely distributed bear species." +
                    " American black bears are omnivores, with their diets varying greatly depending on season and location.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammal",
                    Diet = Nature.DietType.Omnivore,
                    Image = ReadFile("../../Images/BlackBear.jpg")
                },
                new Nature()
                {
                    NatureId = 2,
                    Name = "Bald Eagle",
                    Description = "The bald eagle is a bird of prey found in North America." +
                    " A sea eagle, it has two known subspecies and forms a species pair with the white-tailed eagle," +
                    " which occupies the same niche as the bald eagle in the Palearctic.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Aves",
                    Diet = Nature.DietType.Carnivore,
                    Image = ReadFile("../../Images/BaldEagle.jpg")
                },
                new Nature()
                {
                    NatureId = 3,
                    Name = "Douglas-fir",
                    Description = "The Douglas fir is an evergreen conifer species in the pine family, Pinaceae." +
                    " It is native to western North America and is also known as Douglas-fir, Douglas spruce, Oregon pine, and Columbian pine." +
                    " There are three varieties: coast Douglas-fir, Rocky Mountain Douglas-fir and Mexican Douglas-fir.",
                    Kingdom = Nature.KingdomType.Flora,
                    Class = "Conifer",
                    Diet = Nature.DietType.Other,
                    Image = ReadFile("../../Images/DouglasFir.jpg")
                },
                new Nature()
                {
                    NatureId = 4,
                    Name = "Suillus sibiricus",
                    Description = "Suillus sibiricus is a fungus of the genus Suillus in the family Suillaceae. It is found in mountains of Europe," +
                    " North America, and Siberia, strictly associated with several species of pine tree. Due to its specific habitat and rarity in Europe," +
                    " it has been selected for inclusion in several regional Red Lists.",
                    Kingdom = Nature.KingdomType.Funga,
                    Class = "Agaricomycetes",
                    Diet = Nature.DietType.Other,
                    Image = ReadFile("../../Images/SuillusSibiricus.jpg")
                },
                new Nature()
                {
                    NatureId = 5,
                    Name = "Manatee",
                    Description = "Manatees are large, fully aquatic, mostly herbivorous marine mammals sometimes known as sea cows." +
                    " There are three accepted living species of Trichechidae, representing three of the four living species in the order" +
                    " Sirenia: the Amazonian manatee, the West Indian manatee, and the West African manatee.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammalia",
                    Diet = Nature.DietType.Herbivore,
                    Image = ReadFile("../../Images/Manatee.jpg")
                },
                new Nature()
                {
                    NatureId = 6,
                    Name = "Squirrel",
                    Description = "Squirrels are members of the family Sciuridae, a family that includes small or medium-size rodents." +
                    " The squirrel family includes tree squirrels, ground squirrels, and flying squirrels. Squirrels are indigenous to" +
                    " the Americas, Eurasia, and Africa, and were introduced by humans to Australia. ",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammalia",
                    Diet = Nature.DietType.Omnivore,
                    Image = ReadFile("../../Images/Squirrel.jpg")
                },
                new Nature()
                {
                    NatureId = 7,
                    Name = "Glacier Lily",
                    Description = "Erythronium grandiflorum is a North American species of plants in the lily family." +
                    " It is known by several common names, including yellow avalanche lily, glacier lily, and dogtooth fawn lily.",
                    Kingdom = Nature.KingdomType.Flora,
                    Class = "Liliopsida",
                    Diet = Nature.DietType.Other,
                    Image = ReadFile("../../Images/GlacierLily.jfif")
                },
                new Nature()
                {
                    NatureId = 8,
                    Name = "Moose",
                    Description = "The moose or elk is a member of the New World deer subfamily and is the largest and heaviest extant" +
                    " species in the deer family. Most adult male moose have distinctive broad, palmate antlers; most other members" +
                    " of the deer family have antlers with a dendritic configuration.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammalia",
                    Diet = Nature.DietType.Herbivore,
                    Image = ReadFile("../../Images/Moose.jpg")
                },
                new Nature()
                {
                    NatureId = 9,
                    Name = "Penny Bun",
                    Description = "Boletus edulis is a basidiomycete fungus, and the type species of the genus Boletus. Widely distributed" +
                    " in the Northern Hemisphere across Europe, Asia, and North America, it does not occur naturally in the Southern Hemisphere," +
                    " although it has been introduced to southern Africa, Australia, New Zealand, and Brazil.",
                    Kingdom = Nature.KingdomType.Funga,
                    Class = "Agaricomycetes",
                    Diet = Nature.DietType.Other,
                    Image = ReadFile("../../Images/PennyBun.jpg")
                },
                new Nature()
                {
                    NatureId = 10,
                    Name = "Wolf",
                    Description = "The wolf, also known as the gray wolf or grey wolf, is a large canine native to Eurasia and North America." +
                    " More than thirty subspecies of Canis lupus have been recognized, and gray wolves, as popularly understood, comprise wild" +
                    " subspecies. The wolf is the largest extant member of the family Canidae.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammalia",
                    Diet = Nature.DietType.Carnivore,
                    Image = ReadFile("../../Images/Wolf.jpg")
                },
                new Nature()
                {
                    NatureId = 11,
                    Name = "American Bison",
                    Description = "The American bison, is a species of bison native to North America. Bison are often called buffalo," +
                    " though this term is also used to refer to other bovines. It is one of two extant species of bison, alongside the European bison.",
                    Kingdom = Nature.KingdomType.Fauna,
                    Class = "Mammalia",
                    Diet = Nature.DietType.Herbivore,
                    Image = ReadFile("../../Images/Bison.jpg")
                });

            context.ParkNatures.AddOrUpdate(x => x.ParkNatureId,
                new ParkNature()
                {
                    ParkNatureId = 1,
                    NatureId = 1,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 2,
                    NatureId = 2,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 3,
                    NatureId = 2,
                    ParkId = 2
                },
                new ParkNature()
                {
                    ParkNatureId = 4,
                    NatureId = 3,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 5,
                    NatureId = 4,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 6,
                    NatureId = 6,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 7,
                    NatureId = 7,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 8,
                    NatureId = 8,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 9,
                    NatureId = 9,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 10,
                    NatureId = 10,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 11,
                    NatureId = 11,
                    ParkId = 1
                },
                new ParkNature()
                {
                    ParkNatureId = 12,
                    NatureId = 6,
                    ParkId = 2
                },
                new ParkNature()
                {
                    ParkNatureId = 13,
                    NatureId = 6,
                    ParkId = 3
                },
                new ParkNature()
                {
                    ParkNatureId = 14,
                    NatureId = 6,
                    ParkId = 4
                },
                new ParkNature()
                {
                    ParkNatureId = 15,
                    NatureId = 6,
                    ParkId = 5
                },
                new ParkNature()
                {
                    ParkNatureId = 16,
                    NatureId = 6,
                    ParkId = 6
                },
                new ParkNature()
                {
                    ParkNatureId = 17,
                    NatureId = 6,
                    ParkId = 7
                },
                new ParkNature()
                {
                    ParkNatureId = 18,
                    NatureId = 6,
                    ParkId = 8
                },
                new ParkNature()
                {
                    ParkNatureId = 19,
                    NatureId = 6,
                    ParkId = 9
                },
                new ParkNature()
                {
                    ParkNatureId = 20,
                    NatureId = 6,
                    ParkId = 10
                },
                new ParkNature()
                {
                    ParkNatureId = 21,
                    NatureId = 5,
                    ParkId = 9
                },
                new ParkNature()
                {
                    ParkNatureId = 22,
                    NatureId = 10,
                    ParkId = 6
                },
                new ParkNature()
                {
                    ParkNatureId = 23,
                    NatureId = 10,
                    ParkId = 7
                },
                new ParkNature()
                {
                    ParkNatureId = 24,
                    NatureId = 10,
                    ParkId = 8
                }
                );
        }
    }
}
