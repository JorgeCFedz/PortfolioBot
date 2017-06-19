using System;

namespace PortfolioBot
{
    public class Responses
    {
        public static string[] greetingReply = new string[] { "Hola amigo", "Hi friend", "Hey there", "Aloha" };
        public static string[] farewellReply = new string[] { "Bye. I will miss you friend!", "Adios amigo!", "Have a great day!", "See you soon!" };
        public static String[] tobyImages = new String[] { "Toby_1.jpg", "Toby_2.jpg", "Toby_3.jpg", "Toby_4.jpg", "Toby_5.jpg", "Toby_6.jpg", "Toby_7.jpg", "Toby_8.jpg" };
        public static String[] menuOptions = new String[] { "Bio", "Experience", "Education", "Projects", "skills", "Languages", "Hobbies", "Toby" };
        public static String[] workOptions = new String[] { "HP", "Philips Healthcare" };
        public static String[] projectsOptions = new String[] { "Software", "Biomedical", "Entrepreneurship", "Communication" };
        public static String[] instructions = new string[] 
        {
            "\u274F Type 'instructions' ... to see these instructions",
            "\u274F Type 'menu' ... to open the General Menu",
            "\u274F Type 'jobs' ... to open the jobs Menu",
            "\u274F Type 'projects' ... to open the projects Menu",
            "\u274F Refer to the Navigation map below for other options"
        };

        public const String Summary =
            "Jorge is a full stack Software Developer, currently living as a"
            + " permanent resident in Seattle, WA. He is very passionate"
            + " about technology and innovation, with an emphasis in Computer"
            + " Science and Biotechnology. During the past few years he has"
            + " worked to understand the current edge of technology, and he has"
            + " strived to explore leadership through entrepreneurship and communication. \n\n";

        public const String Projects =
            "His portfolio of projects includes improving Software testing"
            + " efficiency for a major corporation, helping improve ultrasound"
            + " diagnostics by developing a Data engineering tool, helping a"
            + " biotechnology startup migrate patient sensitive data, founding"
            + " a startup to improve irrigation in underdeveloped nations, and"
            + " a startup to improve bladder control in incontinent patients,"
            + " developing an autonomous snack delivery bot, developing a heart"
            + " valve tester, researching the boundary between brain and computer,"
            + " and exploring design and human computer interaction through an"
            + " online art gallery and a tool to help patients track and monitor their medications. \n\n";

        public const String Hobbies =
            "On his free time he enjoys traveling, longboarding with his maltese"
            + " dog Toby, playing the ukelele, drawing, and learning new things."
            + " Don't hesitate to contact him for professional opportunities or simply to make a new friend. \n\n";

        public const String Coursework =
            "Data Structures and Parallelism, Operating Systems, Distributed Systems,"
            + "Data Management, Software Design and Implementation, Web Programming, Software Entrepreneurship,"
            + "Human-Computer Interaction, Robotics, Brain Computer Interfaces";

        public const String TobySummary =
            "Hi There! My name is Toby and I am Jorge's little badass friend! \n\n"
            + "I am currently crashing in Jorge's room but I am open to relocation"
            + " if you can guarantee a package of teenie greenies per month, 2 hours"
            + " of \"insert Jorge's random new outdoor hobby\", and a walk in the park"
            + " 3 times per week.";

        public const String TobyProjects =
            "My list of projects includes griefing the mailman, protecting Jorge"
            + " from imaginary threats, howling, running behind Jorge's longboard"
            + ", and ignoring whoever tries to pet me (I am that cool).";

        public const String TobyHobbies =
            "On my free time I enjoy hatin' on the mailman for no purpose,"
            + " randomly bugging Jorge while he is working, asking for a treat every couple seconds,"
            + ", being the center of the universe, making new friends, and overall having an awesome time!"
            + " Don't hesitate to contact me if you have treats";
    }
}