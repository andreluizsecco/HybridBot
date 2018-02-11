using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;

namespace HybridBot.Dialogs
{
    [Serializable]
    [QnAMaker("{SubscriptionKey}", "{KnowledgeBaseId}", "Não entendi qual sua dúvida, pode explicar melhor?", 0.50, 3)]
    public class QnADialog : QnAMakerDialog { }
}