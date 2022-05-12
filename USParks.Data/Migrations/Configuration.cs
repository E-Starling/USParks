namespace USParks.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<USParks.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "USParks.Data.ApplicationDbContext";
        }

        protected override void Seed(USParks.Data.ApplicationDbContext context)
        {
            context.Parks.AddOrUpdate(x => x.ParkId,
                new Park()
                {
                    ParkId = 1,
                    Name = "Yellowstone",
                    parkType = Park.ParkType.national,
                    Description = "Yellowstone National Park is a nearly 3,500-sq.-mile wilderness recreation area atop a volcanic hot spot. Mostly in Wyoming," +
                    " the park spreads into parts of Montana and Idaho too. Yellowstone features dramatic canyons, alpine rivers, lush forests, hot springs and" +
                    " gushing geysers, including its most famous, Old Faithful. It's also home to hundreds of animal species, including bears, wolves, bison, elk and antelope.",
                    Location = "Wyoming/Montana/Idaho",
                    Size = 3471,
                    YearlyVisitors = 4860000
                },
                new Park()
                {
                    ParkId = 2,
                    Name = "Grand Caynon",
                    parkType = Park.ParkType.national,
                    Description = "Grand Canyon National Park, in Arizona, is home to much of the immense Grand Canyon," +
                    " with its layered bands of red rock revealing millions of years of geological history." +
                    " Viewpoints include Mather Point, Yavapai Observation Station and architect Mary Colter’s Lookout Studio and her Desert View Watchtower." +
                    " Lipan Point, with wide views of the canyon and Colorado River, is a popular, especially at sunrise and sunset.",
                    Location = "Arizona",
                    Size = 1902,
                    YearlyVisitors = 5900000
                },
                new Park()
                {
                    ParkId = 3,
                    Name = "Grand Teton",
                    parkType = Park.ParkType.national,
                    Description = "Grand Teton National Park is an American national park in northwestern Wyoming. At approximately 310,000 acres (1,300 km2)," +
                    " the park includes the major peaks of the 40-mile-long (64 km) Teton Range as well as most of the northern sections of the valley known as Jackson Hole.",
                    Location = "Wyoming",
                    Size = 485,
                    YearlyVisitors = 3890000
                },
                new Park()
                {
                    ParkId = 4,
                    Name = "Turkey Run",
                    parkType = Park.ParkType.state,
                    Description = "Deep canyons nestled in the shadows of sandstone cliffs and peaceful hemlock groves harbor some of the most ruggedly beautiful hiking trails in the state." +
                    " Trails are open from dawn to dusk. To get to many hiking trails you need to cross the suspension bridge over Sugar Creek.",
                    Location = "Indiana",
                    Size = 4,
                    YearlyVisitors = 1000000
                },
                new Park()
                {
                    ParkId = 5,
                    Name = "Indiana Dunes",
                    parkType = Park.ParkType.national,
                    Description = "Indiana Dunes National Park is a United States national park located in northwestern Indiana managed by the National Park Service." +
                    " It was authorized by Congress in 1966 as the Indiana Dunes National Lakeshore and was redesignated as the nation's 61st national park on February 15, 2019.",
                    Location = "Indiana",
                    Size = 24,
                    YearlyVisitors = 3180000
                },
                new Park()
                {
                    ParkId = 6,
                    Name = "Isle Royale",
                    parkType = Park.ParkType.national,
                    Description = "Isle Royale National Park is a remote island cluster in Lake Superior, near Michigan’s border with Canada." +
                    " It’s a car-free wilderness of forests, lakes and waterways, where moose and wolves roam. The Greenstone Ridge Trail links the Windigo Harbor in the west and Rock Harbor in the east." +
                    " The 19th-century Rock Harbor Lighthouse has a small museum. Dive sites in the lake include several shipwrecks."
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
                    ParkId = 1
                },
                new Attraction()
                {
                    AttractionId = 2,
                    Name = "Mather Point",
                    Description = "Scenic viewpoint along South Rim, popular for its canyon vistas & proximity to the visitor center.",
                    ParkId = 2
                },
                new Attraction()
                {
                    AttractionId = 3,
                    Name = "Yavapai Observation Station",
                    Description = "Educational museum on the South Rim offering a topographic relief model of the Grand Canyon.",
                    ParkId = 2
                });

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
                    Diet = Nature.DietType.Omnivore
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
                    Diet = Nature.DietType.Carnivore
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
                    Diet = Nature.DietType.Other
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
                    Diet = Nature.DietType.Other
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
                });
        }
    }
}
