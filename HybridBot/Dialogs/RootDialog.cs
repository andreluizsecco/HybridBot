using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HybridBot.Dialogs
{
    [Serializable]
    [LuisModel("{ModelId}", "{SubscriptionKey}")]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.Forward(new QnADialog(), AfterQnADialog, context.Activity, CancellationToken.None);
        }

        private async Task AfterQnADialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("Saudacao")]
        public async Task Saudacao(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Bem-vindo(a) ao Hotel! Sou o seu atendente virtual, o que deseja?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Reserva")]
        public async Task Reserva(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Ótimo! Esses são os quartos que estão disponíveis...");
            context.Wait(MessageReceived);
        }

        [LuisIntent("ServicoQuarto")]
        public async Task ServicoQuarto(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Entendi, iremos enviar nosso colaborador, qual é o número do seu quarto?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Despertador")]
        public async Task Despertador(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Certo, pode contar comigo, não irei dormir. Que horário deseja ser acordado?");
            context.Wait(MessageReceived);
        }
    }
}