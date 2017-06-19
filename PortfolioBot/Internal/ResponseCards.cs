using AdaptiveCards;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioBot
{
    // Make a template that generates card with different info so this project can be reused!!!!!
    internal static class ResponseCards
    {
        /// <summary>
        ///     Generates a navigational menu for this bot
        ///     TODO: Reduce height of menu card (easier to naviagte on mobile)
        /// </summary>
        /// <returns>a navigation menu card</returns>
        internal static Attachment GenerateMenuCard(String menuType, String[] menuOptions)
        {
            var card = new ThumbnailCard
            {
                Title = "PORTFOLIO BOT \n\n",
                Subtitle = "\u274F " + menuType + " MENU",
                Text = "Click or type your option...",
                Images = new List<CardImage> { new CardImage() { Url = "https://www.jorgecfernandez.com/chatbot/Lionel_Preacherbot_test2.png" } }
            };
            card.Buttons = generateMenuOptions(menuOptions);
            return card.ToAttachment();
        }

        /// <summary>
        ///     Generates a biography for the portfolio author
        /// </summary>
        /// <returns>a biography card</returns>
        internal static Attachment GenerateBioCard()
        {
            var card = new AdaptiveCard();

            card.Body.Add(new Image() { Url = "https://www.jorgecfernandez.com/img/Avatar.jpg", Size = ImageSize.Stretch });
            card.Body.Add(new TextBlock() { Text = "ABOUT ME", Size = TextSize.Large, Weight = TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Center, Separation = SeparationStyle.Strong });
            card.Body.Add(generateBioContainer(Responses.Summary));
            card.Body.Add(generateBioContainer(Responses.Projects));
            card.Body.Add(generateBioContainer(Responses.Hobbies));

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a biography for the dog of this portfolio author
        /// </summary>
        /// <returns>a dog biography card</returns>
        internal static Attachment GenerateTobyCard()
        {
            var card = new AdaptiveCard();
            Random rnd = new Random();
            int index = rnd.Next(Responses.tobyImages.Count());

            card.Body.Add(new Image() { Url = "https://www.jorgecfernandez.com/chatbot/" + Responses.tobyImages[index], Size = ImageSize.Stretch });
            card.Body.Add(new TextBlock() { Text = "TOBY!", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Center, Separation = SeparationStyle.Strong });
            card.Body.Add(generateBioContainer(Responses.TobySummary));
            card.Body.Add(generateBioContainer(Responses.TobyProjects));
            card.Body.Add(generateBioContainer(Responses.TobyHobbies));
            card.Body.Add(new TextBlock() { Text = "Toby bot coming soon..", Size = TextSize.Large, Weight = TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Left, Separation = SeparationStyle.Strong, Color = TextColor.Accent });

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates an education card for the author of this portfolio
        /// </summary>
        /// <returns>an education card</returns>
        internal static Attachment GenerateEducationCard()
        {
            var card = new AdaptiveCard();
            card.Body.Add(new Image() { Url = "https://www.jorgecfernandez.com/chatbot/Education_3.jpg", Size = ImageSize.Stretch });
            card.Body.Add(new TextBlock() { Text = "EDUCATION", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Center, Separation = SeparationStyle.Strong });

            card.Body.Add(new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.None,
                Items = new List<CardElement>
                {
                    new TextBlock() { Separation=SeparationStyle.None, Text = "University of Washington - Seattle (GPA 3.7)", Wrap = true, Size = TextSize.Large, Color = TextColor.Dark, Weight = TextWeight.Bolder},
                    new TextBlock() { Separation=SeparationStyle.None, Text = "\u274F Bachelor of Science in Computer Science", Wrap = true, Size = TextSize.Large},
                    new TextBlock() { Separation=SeparationStyle.None, Text = "\u274F Bachelor of Science in Bioengineering", Wrap = true, Size = TextSize.Large},
                    new TextBlock() { Separation=SeparationStyle.None, Text = "\u274F Minor in Mathematics", Wrap = true, Size = TextSize.Large},
                    new TextBlock() { Separation=SeparationStyle.None, Text = "Awards: Dean's List, 9 quarters", Wrap = true, Size = TextSize.Large, Color = TextColor.Dark, Weight = TextWeight.Lighter, IsSubtle=true},
                    new TextBlock() { Separation=SeparationStyle.None, Text = "2012 - 2016", Wrap = true, Size = TextSize.ExtraLarge, Color = TextColor.Accent},
                }
            });
            card.Body.Add(new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.Default,
                Items = new List<CardElement>
                {
                    new TextBlock() { Separation=SeparationStyle.None, Text = "Coursework", Wrap = true, Size = TextSize.Medium, Weight = TextWeight.Bolder},
                    new TextBlock() { Separation=SeparationStyle.None, Text = Responses.Coursework, Wrap = true, Size = TextSize.Normal},
                }
            });

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a work card for the selected role
        /// </summary>
        /// <param name="option"></param>
        /// <returns>a work card</returns>
        internal static Attachment GenerateWorkCard(String option)
        {
            String title = "";
            String image = "";
            String date = "";
            String[] roleTasks = new String[] { };
            
            switch (option)
            {
                case "HP":
                    title = "Software Engineer   |   Hewlett Packard";
                    image = "HP.gif";
                    date = "Jul 2015 - May 2016";
                    roleTasks = new String[] 
                    {
                        "Updated supplies C# testing suite to utilize HP CTF 2.0 framework",
                        "Automated supplies testing by updating and using existing XML serialization",
                        "Consolidated number of tests from 1115 to 143 by making tests product independent",
                        "Reduced testing time from 1 - 2 days to 2 hours by eliminating bottlenecks and testing redundancy, and differentiating product failure from software error"
                    };
                    break;
                case "Philips Healthcare":
                    title = "Data Analyst   |   Philips Healthcare";
                    image = "PhilipsHealthcare.png";
                    date = "Sep 2014 - Jun 2015";
                    roleTasks = new String[]
                    {
                        "Implemented and automated parsing, aggregation, preprocessing and flattening of ultrasound XML data using Java",
                        "Analyzed data and presented results using Tableau to reduce production costs, increase ultrasound efficiency and improve patient outcomes"
                    };
                    break;
            }

            var card = new AdaptiveCard();
            card.Body.Add(new Image() { Url = "https://www.jorgecfernandez.com/chatbot/" + image, Size = ImageSize.Stretch });
            card.Body.Add(new TextBlock() { Text = "WORK EXPERIENCE", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Center, Separation = SeparationStyle.Strong });
            card.Body.Add(PopulateWorkCard(roleTasks, title, date));

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a languages card for the user of this portfolio
        /// </summary>
        /// <returns>a languages card</returns>
        internal static Attachment GenerateInstructionsCard()
        {
            var card = new AdaptiveCard();
            // header
            card.Body.Add(new ColumnSet()
            {
                Columns = new List<Column>
                {
                    new Column()
                    {
                        Style = ContainerStyle.Normal,
                        Separation=SeparationStyle.Strong,
                        Items = new List<CardElement>
                        {
                            new TextBlock() { Text = "PORTFOLIO BOT", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, Separation = SeparationStyle.Default },
                            new TextBlock() { Text = "Instructions", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, Color=TextColor.Accent, Separation = SeparationStyle.None },
                        }
                    },
                    new Column()
                    {
                        Separation=SeparationStyle.None,
                        Items = new List<CardElement>{ new Image(){ Url = "https://www.jorgecfernandez.com/chatbot/Lionel_Preacherbot_test2.png", HorizontalAlignment = HorizontalAlignment.Right, Size=ImageSize.Medium } }
                    }
                }
            });
            // Instructions
            card.Body.Add(new TextBlock() { Text = "Options", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            foreach (var instruction in Responses.instructions)
            {
                card.Body.Add(GenerateInstruction(instruction));
            }
            // Navigation Map
            card.Body.Add(new TextBlock() { Text = "Navigation Map", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.None,
                SelectAction = new OpenUrlAction { Url = "https://www.jorgecfernandez.com/chatbot/NavigationMap_centered.png" },
                Items = new List<CardElement>
                {
                    new Image() { Size = ImageSize.Stretch, Separation = SeparationStyle.None, Url = "https://www.jorgecfernandez.com/chatbot/NavigationMap_centered.png" },
                }
            });
            card.Actions.Add(new OpenUrlAction() { Title = "Click to expand image", Url = "https://www.jorgecfernandez.com/chatbot/NavigationMap_centered.png" });

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a skill card for the user of this portfolio
        /// </summary>
        /// <returns>a skill card</returns>
        internal static Attachment GenerateSkillsCard()
        {
            var card = new AdaptiveCard();

            card.Body.Add(new TextBlock() { Text = "PROGRAMMING LANGUAGES", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, Separation = SeparationStyle.Default });
            card.Body.Add(new TextBlock() { Text = "Object Oriented Programming", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("Java", "Proficient", "https://www.jorgecfernandez.com/chatbot/Java_icon_small.png"));
            card.Body.Add(generateSkillContainer("C#", "Proficient", "https://www.jorgecfernandez.com/chatbot/C_Sharp.png"));
            card.Body.Add(generateSkillContainer("C++", "Competent", "https://www.jorgecfernandez.com/chatbot/Cpp.png"));
            card.Body.Add(new TextBlock() { Text = "Procedural", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("C", "Proficient", "https://www.jorgecfernandez.com/chatbot/C.gif"));
            card.Body.Add(new TextBlock() { Text = "Web Programming", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("Javascript", "Competent", "https://www.jorgecfernandez.com/chatbot/JS.png"));
            card.Body.Add(generateSkillContainer("php", "Familiar", "https://www.jorgecfernandez.com/chatbot/php.png"));
            card.Body.Add(generateSkillContainer("HTML5", "Proficient", "https://www.jorgecfernandez.com/chatbot/HTML5.png"));
            card.Body.Add(generateSkillContainer("CSS3", "Proficient", "https://www.jorgecfernandez.com/chatbot/CSS3.ico"));
            card.Body.Add(new TextBlock() { Text = "Database Management and Serialization", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("SQL", "Competent", "https://www.jorgecfernandez.com/chatbot/SQL.png"));
            card.Body.Add(generateSkillContainer("XML", "Competent", "https://www.jorgecfernandez.com/chatbot/XML.png"));
            card.Body.Add(generateSkillContainer("JSON", "Competent", "https://www.jorgecfernandez.com/chatbot/JSON.png"));
            card.Body.Add(new TextBlock() { Text = "Others", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("NI LabVIEW (graphical)", "Familiar", "https://www.jorgecfernandez.com/chatbot/NI_LabVIEW.png"));
            card.Body.Add(generateSkillContainer("Haskell (functional)", "Familiar", "https://www.jorgecfernandez.com/chatbot/Haskell.png"));
            card.Body.Add(generateSkillContainer("Matlab (multi-paradigm)", "Familiar", "https://www.jorgecfernandez.com/chatbot/Matlab.png"));

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a languages card for the user of this portfolio
        /// </summary>
        /// <returns>a languages card</returns>
        internal static Attachment GenerateLanguagesCard()
        {
            var card = new AdaptiveCard();
            card.Body.Add(new TextBlock() { Text = "LANGUAGES", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, Separation = SeparationStyle.Default });
            card.Body.Add(generateSkillContainer("English", "Native", "https://www.jorgecfernandez.com/chatbot/English_Flag.ico"));
            card.Body.Add(generateSkillContainer("Spanish", "Native", "https://www.jorgecfernandez.com/chatbot/Spanish_Flag.ico"));
            card.Body.Add(generateSkillContainer("French", "Advanced", "https://www.jorgecfernandez.com/chatbot/French_Flag.png"));

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generates a hobbies card for the user of this portfolio
        /// </summary>
        /// <returns>a hobbies card</returns>
        internal static Attachment GenerateHobbiesCard()
        {
            var card = new AdaptiveCard();
            card.Body.Add(new TextBlock() { Text = "Hobbies", Size = TextSize.ExtraLarge, Weight = TextWeight.Bolder, Separation = SeparationStyle.Default });
            card.Body.Add(new TextBlock() { Text = "Recreational Activities", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("Ukelele", "Amateur", "https://www.jorgecfernandez.com/chatbot/Ukelele.png"));
            card.Body.Add(generateSkillContainer("Longboarding", "Amateur", "https://www.jorgecfernandez.com/chatbot/Longboarding.png"));
            card.Body.Add(generateSkillContainer("Snowboarding", "Amateur", "https://www.jorgecfernandez.com/chatbot/Snowboarding.ico"));
            card.Body.Add(generateSkillContainer("Painting", "Amateur", "https://www.jorgecfernandez.com/chatbot/Painting.png"));
            card.Body.Add(generateSkillContainer("Traveling", "Advanced", "https://www.jorgecfernandez.com/chatbot/Traveling.ico"));
            card.Body.Add(new TextBlock() { Text = "Science Topics", Size = TextSize.Large, Weight = TextWeight.Bolder, Separation = SeparationStyle.Strong, HorizontalAlignment = HorizontalAlignment.Center });
            card.Body.Add(generateSkillContainer("Theoretical Physics", "Amateur", "https://www.jorgecfernandez.com/chatbot/Physics.png"));
            card.Body.Add(generateSkillContainer("Genome Engineering", "Amateur", "https://www.jorgecfernandez.com/chatbot/Genome.png"));
            card.Body.Add(generateSkillContainer("Robotics", "Amateur", "https://www.jorgecfernandez.com/chatbot/Robotics.jpg"));
            card.Body.Add(generateSkillContainer("Virtual Reality", "Amateur", "https://www.jorgecfernandez.com/chatbot/VR.png"));
            card.Body.Add(generateSkillContainer("Artificial Intelligence", "Amateur", "https://www.jorgecfernandez.com/chatbot/AI.png"));
            card.Body.Add(generateSkillContainer("Brain Computer Interfaces", "Amateur", "https://www.jorgecfernandez.com/chatbot/BCI.png"));

            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }

        /// <summary>
        ///     Generate a list of software projects
        /// </summary>
        /// <returns>the list of software projects</returns>
        internal static List<Attachment> GenerateSoftwareProjectsCard()
        {
            return new List<Attachment>()
            {
                new HeroCard
                {
                    Title = "Portfolio Bot",
                    Subtitle = "Spring 2017",
                    Text = "Created chatbot using Microsoft Azure bot framework, the .NET platform, and C#.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/MSFTAzurebot.jpg" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Portfolio Page",
                    Subtitle = "Spring 2017",
                    Text = "Created professional portfolio using HTML5, CSS3, JS, jQuery, and W3.CSS.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/Portfolio.jpg" } },
                    Buttons = new List<CardAction>() { new CardAction() { Title = "Go to page", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "DTs & Algs",
                    Subtitle = "Spring 2017",
                    Text = "Implemented most used Data Structures and Algorithms using Java, a matching JUnit testing suite, and JavaDoc documentation.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/DTS&Algs.jpg" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Snacbot",
                    Subtitle = "Spring 2016",
                    Text = "Created a robot using roomba and turtlebot skeletons, C++, ROS frameworks, Arduino, and a web UI.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/Snacbot.png" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Blog", Type = ActionTypes.OpenUrl, Value = "https://fsgris.tumblr.com/" },
                        new CardAction() { Title = "Demo", Type = ActionTypes.OpenUrl, Value = "https://youtu.be/EEMcHujPXc4" }
                    },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "HP",
                    Subtitle = "Summer 2015 – Winter 2016",
                    Text = "Updated and automated supplies C# testing suite, consolidated number of tests from 1000+ to less than 200, and reduced testing time from 1-2 days to over 2 hours.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/HPfair.jpg" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Philips Healthcare",
                    Subtitle = "Summer 2014 – Spring 2015",
                    Text = "Implemented and automated parsing, aggregation, preprocessing and flattening of ultrasound XML data using Java.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/PhilipsUltrasounds.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Presentation", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Pitch_Jorge_Fernandez_Medical_Ultrasonography.pdf" },
                        new CardAction() { Title = "Capstone Report", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Jorge_Fernandez_Philips_Capstone_Report.pdf" }
                    },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "UW Campus Navigation Map",
                    Subtitle = "Spring 2014",
                    Text = "Implemented a navigation app using Djikstra algorithm, and following the MVC pattern with a graph DT for the model, a Java SWING GUI for the view, and a small Java controller.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/UW_CampusMap2.jpg" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Word Frequency Analyzer",
                    Subtitle = "Winter 2014",
                    Text = "Implemented a Word Frequency Analyzer using popular Data Structures and Algorithms like AVL tree, Hash table, heap sort...",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/WordFrequencyAnalyzer.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Report 1", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/WordFA_BenchmarkI.pdf" },
                        new CardAction() { Title = "Report 2", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/WordFA_BenchmarkII.pdf" },
                        new CardAction() { Title = "Report 3", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/WordFA_BenchmarkIII.pdf" }
                    },
                }.ToAttachment(),
            };
        }

        /// <summary>
        ///     Generate a list of biomedical projects
        /// </summary>
        /// <returns>the list of bioemdical projects</returns>
        internal static List<Attachment> GenerateBiomedicalProjectsCard()
        {
            return new List<Attachment>()
            {
                new HeroCard
                {
                    Title = "Brain Computer Interfaces",
                    Subtitle = "Spring 2016",
                    Text = "Analysis of the current state of the art in the field of BCIs, including standard BCIs, neuroplasticity, sensory feedback, and synergiess.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/BCIs2.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Presentation", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/PlasticBrainsAndAdaptingInterfaces.pdf" },
                        new CardAction() { Title = "Report", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/BCIsReport.pdf" },
                    },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Heart Valve Tester",
                    Subtitle = "Fall 2013",
                    Text = "Design and manufacture of a low-cost artificial heart valve tester using LabVIEW, 3D printing, and custom made heart valves.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/HeartValve_Tester.jpg" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Other Projects",
                    Subtitle = "Section under construction...",
                    Text = "Make sure to check back for more projects!",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/chatbot/UnderConstruction.png" } },
                }.ToAttachment()
            };
        }

        /// <summary>
        ///     Generate a list of entrepreneurship projects
        /// </summary>
        /// <returns>the list of entrepreneurship projects</returns>
        internal static List<Attachment> GenerateEntrepreneurshipProjectsCard()
        {
            return new List<Attachment>()
            {
                new HeroCard
                {
                    Title = "VR Consulting Agency",
                    Subtitle = "Spring 2016",
                    Text = "Technological and business analysis of current state of the art for Virtual, Augmented, and Mixed reality including devices, challenges, and trends.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/VRAgency.jpg" } },
                    Buttons = new List<CardAction>() { new CardAction() { Title = "Business Plan", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/VRAgency.pdf" } },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Smarty Pants",
                    Subtitle = "Spring 2015",
                    Text = "Bluetooth low energy bladder sensor for incontinent patients.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/SmartyPants3.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Business Plan", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/SmartyPants_BusinessPlan.pdf" },
                        new CardAction() { Title = "2015 BPC Prize", Type = ActionTypes.OpenUrl, Value = "http://depts.washington.edu/foster/75000-awarded-to-student-led-startups/" },
                    },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Trackscription",
                    Subtitle = "Winter 2015",
                    Text = "Design, user research, field testing, and digital mockup of a Smart pill capsule and pairing android app for managing medications.",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/Trackscription.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Poster", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/TrackscriptionFinalPoster.png" },
                        new CardAction() { Title = "Report", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Trackscription_Report.pdf" },
                        new CardAction() { Title = "Video Presentation", Type = ActionTypes.OpenUrl, Value = "https://www.youtube.com/watch?v=3WtMc_xZlI4&feature=youtu.be" },
                        new CardAction() { Title = "Invision Prototype", Type = ActionTypes.OpenUrl, Value = "https://projects.invisionapp.com/share/BK2DIGKZ5#/screens" }
                    },
                }.ToAttachment(),
                new HeroCard
                {
                    Title = "Terramizu",
                    Subtitle = "Fall 2014 - Spring 2015",
                    Text = "Design, manufacture, and crop yield testing in greenhouse of custom made water permeable clay pipes with assorted recipe concentrations for the rural poor."
                    + " 2015 Environmental Innovation Challenge finalist   |   2015 Agricultural Innovation Prize finalist",
                    Images = new List<CardImage>() { new CardImage() { Url = "https://www.jorgecfernandez.com/img/Terramizu.jpg" } },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction() { Title = "Poster", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Terramizu_EIC_poster.pdf" },
                        new CardAction() { Title = "EIC Team", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Terramizu_EIC_Team.jpg" },
                        new CardAction() { Title = "Full Team", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Terramizu_team.jpg" },
                        new CardAction() { Title = "Logo", Type = ActionTypes.OpenUrl, Value = "https://www.jorgecfernandez.com/doc/Terramizu_logo.jpg" }
                    },
                }.ToAttachment()
            };
        }

        /// <summary>
        ///     Generate a list of communication projects
        /// </summary>
        /// <returns>the list of communication projects</returns>
        internal static List<Attachment> GenerateCommunicationProjectsCard()
        {
            return new List<Attachment>()
            {
                new VideoCard
                {
                    Title = "Storytelling Speech",
                    Subtitle = "Spring 2016",
                    Text = "Storytelling speech narrating my adventure running the San Fermines",
                    Media = new List<MediaUrl>() { new MediaUrl() { Url = "https://youtu.be/fRox8xf0MOk" } },
                    Shareable = false
                }.ToAttachment(),
                new VideoCard
                {
                    Title = "Impromptu Speech",
                    Subtitle = "Winter 2016",
                    Text = "Impromptu speech with 5 minutes preparation arguing against enforcing mandatory minors for college students",
                    Media = new List<MediaUrl>() { new MediaUrl() { Url = "https://youtu.be/xD-Rxgr0HPw" } },
                    Shareable = false
                }.ToAttachment(),
                new VideoCard
                {
                    Title = "Persuasive Speech",
                    Subtitle = "Winter 2016",
                    Text = "Persuasive speech arguing in favor of mandatory body cameras for law enforcement officers.",
                    Media = new List<MediaUrl>() { new MediaUrl() { Url = "https://youtu.be/JA6dgAjubFA" } },
                    Shareable = false
                }.ToAttachment(),
                new VideoCard
                {
                    Title = "Crisis Speech",
                    Subtitle = "Spring 2016",
                    Text = "The last rocket mission crashed! first crisis response with 24 hours preparation to ease public opinion.",
                    Media = new List<MediaUrl>() { new MediaUrl() { Url = "https://youtu.be/v_dZNT9siaQ" } },
                    Shareable = false
                }.ToAttachment(),
            };
        }

        #region Private
        // generates the buttons for a menu of options card
        internal static List<CardAction> generateMenuOptions(String[] menuOptions)
        {
            var buttons = new List<CardAction>();
            foreach (var option in menuOptions)
            {
                buttons.Add(new CardAction() { Title = option, Type = ActionTypes.ImBack, Value = option });
            }
            return buttons;
        }

        // Generate a instruction for the instructions card
        private static Container GenerateInstruction(String instruction)
        {
            return new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.None,
                Items = new List<CardElement>() { new TextBlock() { Text = instruction, Wrap=true } }
            };
        }

        // populates the role info for the work card
        private static Container PopulateWorkCard(String[] roleTasks, String title, String date)
        {
            var items = new List<CardElement>
            {
                new TextBlock() { Separation=SeparationStyle.None, Text = title, Wrap = true, Size = TextSize.Large, Color = TextColor.Dark, Weight = TextWeight.Bolder},
                new TextBlock() { Separation=SeparationStyle.None, Text = date, Wrap = true, Size = TextSize.ExtraLarge, Color = TextColor.Accent}
            };
            return GenerateRoleTasks(roleTasks, items);
        }


        // populates the role tasks for the work card
        private static Container GenerateRoleTasks(String[] roleTasks, List<CardElement> items)
        {
            foreach (var task in roleTasks)
            {
                items.Add(new TextBlock() { Separation = SeparationStyle.None, Text = "\u274F " + task, Wrap = true, Size = TextSize.Normal });
            }
            return new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.None,
                Items = items
            };
        }

        // Generates a skill for the skill card
        private static Container generateSkillContainer(String language, String level, String url)
        {
            return new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.None,
                Items = new List<CardElement>
                {
                    generateSkillColumnSet(language, level, url)
                }
            };
        }


        // Generates a bio box for the Biography and Dog cards
        private static Container generateBioContainer(String paragraph)
        {
            return new Container()
            {
                Style = ContainerStyle.Emphasis,
                Separation = SeparationStyle.Default,
                Items = new List<CardElement>
                {
                    new TextBlock() { Separation=SeparationStyle.None, Text = paragraph, Wrap = true},
                }
            };
        }

        // Generates a skill column layout for each skill
        private static ColumnSet generateSkillColumnSet(String language, String level, String url)
        {
            return new ColumnSet()
            {
                //Separation=SeparationStyle.Strong,
                Columns = new List<Column>
                {
                    new Column()
                    {
                        Style = ContainerStyle.Normal,
                        Separation=SeparationStyle.Strong,
                        Items = new List<CardElement>
                        {
                            new TextBlock(){ Text=language, Size=TextSize.Medium, Weight=TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Left, Color=TextColor.Accent, Separation=SeparationStyle.Strong },
                            new TextBlock(){ Text=level, Size=TextSize.Small, Weight=TextWeight.Bolder, HorizontalAlignment = HorizontalAlignment.Left, Color=TextColor.Dark, Separation=SeparationStyle.None }
                        }

                    },
                    new Column()
                    {
                        Items = new List<CardElement>{ new Image(){ Url =url, HorizontalAlignment = HorizontalAlignment.Right, Size=ImageSize.Small } }
                    }
                }
            };
        }
        #endregion
    }
}