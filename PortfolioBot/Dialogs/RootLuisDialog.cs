using System;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Luis;
using System.Threading;
using Microsoft.Bot.Connector;

namespace PortfolioBot
{
    [LuisModel("YourModelId", "YourSubscriptionKey")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<Object>
    {
        public RootLuisDialog(params ILuisService[] services) : base(services)
        {
        }

        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            // example: handling a greeting with a child dialog instead of LUIS
            var cts = new CancellationTokenSource();
            await context.Forward(new ChildsDialog(), ChildsDialogDone, await message, cts.Token);
        }

        [LuisIntent("Instructions")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            var message = GetInstructionsCard(context);
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("General Menu")]
        public async Task GeneralMenu(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateMenuCard("GENERAL", Responses.menuOptions));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("AboutMe")]
        public async Task AboutMe(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateBioCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Skills")]
        public async Task Skills(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateSkillsCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Languages")]
        public async Task Languages(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateLanguagesCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hobbies")]
        public async Task Hobbies(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateHobbiesCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Education")]
        public async Task Education(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateEducationCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Toby")]
        public async Task Toby(IDialogContext context, LuisResult result)
        {

            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateTobyCard());
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Projects")]
        public async Task Projects(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateMenuCard("PROJECTS", Responses.projectsOptions));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("WorkExperience")]
        public async Task WorkExperience(IDialogContext context, LuisResult result)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateMenuCard("JOBS", Responses.workOptions));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        #region Private
        private IMessageActivity GetInstructionsCard(IDialogContext context)
        {
            var message = context.MakeMessage();
            message.Attachments.Add(ResponseCards.GenerateInstructionsCard());
            return message;
        }

        private async Task ChildsDialogDone(IDialogContext context, IAwaitable<bool> result)
        {
            var success = await result;
            if (!success)
            {
                await context.PostAsync("I'm sorry. I didn't understand you.");     
                var message = GetInstructionsCard(context);
                await context.PostAsync(message);
            }
            context.Wait(MessageReceived);                                              
        }
        #endregion
    }
}