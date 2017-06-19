using BestMatchDialog;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace PortfolioBot
{
    [Serializable]
    public class ChildsDialog: BestMatchDialog<bool>
    {
        private const string HP_Option = "HP";

        private const string PhilipsHealthcare_Option = "Philips Healthcare";


        [BestMatch(new string[] { "Hi", "Hi There", "Hello there", "Hey", "Hello",
            "Hey there", "Greetings", "Good morning", "Good afternoon", "Good evening", "Good day",
            "Hola", "Salut", "Bon jour", "wassup", "howdy", "what is up" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task WelcomeGreeting(IDialogContext context, string messageText)
        {
            Random rnd = new Random();
            int index = rnd.Next(Responses.greetingReply.Count());
            String greeting = Responses.greetingReply[index] + ". How can I help you?";
            await context.PostAsync(greeting);
            context.Done(true);
        }

        [BestMatch(new string[] { "bye", "bye bye", "got to go",
            "see you later", "laters", "adios", "peace out", "arrivederci", "au revoir" })]
        public async Task FarewellGreeting(IDialogContext context, string messageText)
        {
            Random rnd = new Random();
            int index = rnd.Next(Responses.farewellReply.Count());
            String greeting = Responses.farewellReply[index];
            await context.PostAsync(greeting);
            context.Done(true);
        }

        [BestMatch(new string[] { "HP", "Hewlett Packard", "HP Inc", "HP Enterprise", "HP option",
            "HP option", "option HP", "see HP" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task HP(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateWorkCard(HP_Option));
            await context.PostAsync(message);
            context.Done(true);
        }

        [BestMatch(new string[] { "Philips", "Philips Healthcare", "see Philips", "see Philips Healthcare", "Philips option",
            "option Philips", "Philips Healthcare option", "option Philips Healthcare" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task Philips(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateWorkCard(PhilipsHealthcare_Option));
            await context.PostAsync(message);
            context.Done(true);
        }

        [BestMatch(new string[] { "Software", "Software projects", "Software option", "see Software",
            "SW", "SW projects", "SW option", "see SW", "Computer", "Computer projects",
            "Computer option", "see Computer", "Programming", "Programming projects",
            "Programming option", "see Programming" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task Software(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = ResponseCards.GenerateSoftwareProjectsCard();
            await context.PostAsync(message);
            context.Done(true);
        }

        [BestMatch(new string[] { "Biomedical", "Biomedical projects", "Biomedical option", "see Biomedical", "Bioe", "Bioe projects", "Bioe option",
            "see Bioe", "Bioengineering", "Bioengineering projects", "Bioengineering option", "see Bioengineering", "Healthcare", "Healthcare projects",
            "Healthcare option", "see Healthcare" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task Biomedical(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = ResponseCards.GenerateBiomedicalProjectsCard();
            await context.PostAsync(message);
            context.Done(true);
        }

        [BestMatch(new string[] { "Entrepreneurship", "Entrepreneurship projects", "Entrepreneurship option", "see Entrepreneurship",
            "Entre", "Entre projects", "Entre option","see Entre", "Business", "Business projects", "Business option", "see Business" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task Entrepreneurship(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = ResponseCards.GenerateEntrepreneurshipProjectsCard();
            await context.PostAsync(message);
            context.Done(true);
        }

        [BestMatch(new string[] { "Communication", "Communication projects", "Communication option", "see Communication",
            "Com", "Com projects", "Com option", "see Com", "Public speaking", "Public speaking projects", "Public speaking option",
            "see Public speaking", "Speech", "Speech projects", "Speech option", "see Speech" },
            threshold: 0.5, ignoreCase: true, ignoreNonAlphaNumericCharacters: true)]
        public async Task Communication(IDialogContext context, string messageText)
        {
            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = ResponseCards.GenerateCommunicationProjectsCard();
            await context.PostAsync(message);
            context.Done(true);
        }

        public override async Task NoMatchHandler(IDialogContext context, string messageText)
        {
            context.Done(false);
        }
    }
}