using System;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TZ_sogaz.Services
{
    public static class BotActionController
    {
        private static TelegramBotClient client;

        static BotActionController()
        {
            client = new TelegramBotClient("1773704934:AAHqaKIOqNNEq4ZATsk_VkoWJRHC2IqriVc");
        }

        public static void ChatMessage(Update update)
        {
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    OnMessage(update);
                    break;
                //case Telegram.Bot.Types.Enums.UpdateType.Unknown:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.InlineQuery:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.ChosenInlineResult:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.EditedMessage:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.ChannelPost:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.EditedChannelPost:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.ShippingQuery:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.PreCheckoutQuery:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.Poll:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.PollAnswer:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.MyChatMember:
                //    break;
                //case Telegram.Bot.Types.Enums.UpdateType.ChatMember:
                //    break;
                default:
                    break;
            }
        }

        private static void OnMessage(Update update)
        {
            switch (update.Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    UserSendTextMessage(update);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                case Telegram.Bot.Types.Enums.MessageType.Audio:
                case Telegram.Bot.Types.Enums.MessageType.Video:
                case Telegram.Bot.Types.Enums.MessageType.Voice:
                case Telegram.Bot.Types.Enums.MessageType.Document:
                case Telegram.Bot.Types.Enums.MessageType.Sticker:
                case Telegram.Bot.Types.Enums.MessageType.Location:
                    UserAccessControl(update);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.ChatMembersAdded:
                    AddMembersInDB(update);
                    break;
                default:
                    break;
            }

        }

        private static void AddMembersInDB(Update update)
        {
            foreach (var user in update.Message.NewChatMembers)
            {
                UserInfo newUser = new UserInfo(user.Username);
                DataBase.AddNewUser(newUser);
            }
        }

        private static async void UserAccessControl(Update update)
        {
            UserInfo user = DataBase.GetUserByUsername(update.Message.From.Username);

            if (user != null)
            {
                if (user.canSendOnlyText)
                {
                    await client.DeleteMessageAsync(update.Message.Chat, update.Message.MessageId);
                }
            }
        }

        private static void UserSendTextMessage(Update update) 
        {
            UserInfo user = DataBase.GetUserByUsername(update.Message.From.Username);

            if (user != null)
            {
                DataBase.UpdateUserMessages(user);
            }
        }

        private static void BotSendTextMessage() 
        {

        }
    }
}
