////
//// Summary:
////     The type Message.

//using System;
//using Newtonsoft.Json;
//using System.Collections.Generic;

//namespace MSGraphService.Models.Old
//{
//    //
//    // Summary:
//    //     The enum Importance.
//    public enum Importance
//    {
//        //
//        // Summary:
//        //     low
//        Low = 0,

//        //
//        // Summary:
//        //     normal
//        Normal = 1,

//        //
//        // Summary:
//        //     high
//        High = 2
//    }

////
//// Summary:
////     The enum FollowupFlagStatus.
//    public enum FollowupFlagStatus
//    {
//        //
//        // Summary:
//        //     not Flagged
//        NotFlagged = 0,

//        //
//        // Summary:
//        //     complete
//        Complete = 1,

//        //
//        // Summary:
//        //     flagged
//        Flagged = 2
//    }

////
//// Summary:
////     The enum BodyType.
//    public enum BodyType
//    {
//        //
//        // Summary:
//        //     text
//        Text = 0,

//        //
//        // Summary:
//        //     html
//        Html = 1
//    }

//    public class Message: Entity
//    {
//        public Message()
//        {

//        }

//        // Summary:
//        //     Gets or sets flag. The flag value that indicates the status, start date, due
//        //     date, or completion date for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flag", Required = Required.Default)]
//        public FollowupFlag Flag { get; set; }

//        // Summary:
//        //     Gets or sets web link. The URL to open the message in Outlook Web App.You can
//        //     append an ispopout argument to the end of the URL to change how the message is
//        //     displayed. If ispopout is not present or if it is set to 1, then the message
//        //     is shown in a popout window. If ispopout is set to 0, then the browser will show
//        //     the message in the Outlook Web App review pane.The message will open in the browser
//        //     if you are logged in to your mailbox via Outlook Web App. You will be prompted
//        //     to login if you are not already logged in with the browser.This URL can be accessed
//        //     from within an iFrame.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "webLink",
//            Required = Required.Default)]
//        public string WebLink { get; set; }

//        //
//        // Summary:
//        //     Gets or sets is draft. Indicates whether the message is a draft. A message is
//        //     a draft if it hasn't been sent yet.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isDraft",
//            Required = Required.Default)]
//        public bool? IsDraft { get; set; }

//        //
//        // Summary:
//        //     Gets or sets is read. Indicates whether the message has been read.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isRead",
//            Required = Required.Default)]
//        public bool? IsRead { get; set; }

//        //
//        // Summary:
//        //     Gets or sets is read receipt requested. Indicates whether a read receipt is requested
//        //     for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isReadReceiptRequested",
//            Required = Required.Default)]
//        public bool? IsReadReceiptRequested { get; set; }

//        //
//        // Summary:
//        //     Gets or sets is delivery receipt requested. Indicates whether a read receipt
//        //     is requested for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isDeliveryReceiptRequested",
//            Required = Required.Default)]
//        public bool? IsDeliveryReceiptRequested { get; set; }

//        //
//        // Summary:
//        //     Gets or sets unique body. The part of the body of the message that is unique
//        //     to the current message. uniqueBody is not returned by default but can be retrieved
//        //     for a given message by use of the ?$select=uniqueBody query. It can be in HTML
//        //     or text format.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "uniqueBody",
//            Required = Required.Default)]
//        public ItemBody UniqueBody { get; set; }

//        //
//        // Summary:
//        //     Gets or sets conversation id. The ID of the conversation the email belongs to.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "conversationId",
//            Required = Required.Default)]
//        public string ConversationId { get; set; }

//        //
//        // Summary:
//        //     Gets or sets reply to. The email addresses to use when replying.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "replyTo",
//            Required = Required.Default)]
//        public IEnumerable<Recipient> ReplyTo { get; set; }

//        //
//        // Summary:
//        //     Gets or sets bcc recipients. The Bcc: recipients for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bccRecipients",
//            Required = Required.Default)]
//        public IEnumerable<Recipient> BccRecipients { get; set; }

//        //
//        // Summary:
//        //     Gets or sets cc recipients. The Cc: recipients for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "ccRecipients",
//            Required = Required.Default)]
//        public IEnumerable<Recipient> CcRecipients { get; set; }

//        //
//        // Summary:
//        //     Gets or sets to recipients. The To: recipients for the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "toRecipients",
//            Required = Required.Default)]
//        public IEnumerable<Recipient> ToRecipients { get; set; }

//        //
//        // Summary:
//        //     Gets or sets from. The mailbox owner and sender of the message. The value must
//        //     correspond to the actual mailbox used.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from", Required = Required.Default)]
//        public Recipient From { get; set; }

//        //
//        // Summary:
//        //     Gets or sets sender. The account that is actually used to generate the message.
//        //     In most cases, this value is the same as the from property. You can set this
//        //     property to a different value when sending a message from a shared mailbox, or
//        //     sending a message as a delegate. In any case, the value must correspond to the
//        //     actual mailbox used.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender",
//            Required = Required.Default)]
//        public Recipient Sender { get; set; }

//        //
//        // Summary:
//        //     Gets or sets parent folder id. The unique identifier for the message's parent
//        //     mailFolder.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parentFolderId",
//            Required = Required.Default)]
//        public string ParentFolderId { get; set; }

//        //
//        // Summary:
//        //     Gets or sets importance. The importance of the message: Low, Normal, High.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "importance",
//            Required = Required.Default)]
//        public Importance? Importance { get; set; }

//        //
//        // Summary:
//        //     Gets or sets body preview. The first 255 characters of the message body. It is
//        //     in text format.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bodyPreview",
//            Required = Required.Default)]
//        public string BodyPreview { get; set; }

//        //
//        // Summary:
//        //     Gets or sets body. The body of the message. It can be in HTML or text format.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "body", Required = Required.Default)]
//        public ItemBody Body { get; set; }

//        //
//        // Summary:
//        //     Gets or sets subject. The subject of the message.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject",
//            Required = Required.Default)]
//        public string Subject { get; set; }

//        // Summary:
//        //     Gets or sets internet message id. The message ID in the format specified by RFC2822.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "internetMessageId",
//            Required = Required.Default)]
//        public string InternetMessageId { get; set; }

//        //
//        // Summary:
//        //     Gets or sets has attachments. Indicates whether the message has attachments.
//        //     This property doesn't include inline attachments, so if a message contains only
//        //     inline attachments, this property is false. To verify the existence of inline
//        //     attachments, parse the body property to look for a src attribute, such as &lt;IMG
//        //     src='cid:image001.jpg@01D26CD8.6C05F070'&gt;.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hasAttachments",
//            Required = Required.Default)]
//        public bool? HasAttachments { get; set; }

//        //
//        // Summary:
//        //     Gets or sets sent date time. The date and time the message was sent.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sentDateTime",
//            Required = Required.Default)]
//        public DateTimeOffset? SentDateTime { get; set; }

//        //
//        // Summary:
//        //     Gets or sets received date time. The date and time the message was received.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receivedDateTime",
//            Required = Required.Default)]
//        public DateTimeOffset? ReceivedDateTime { get; set; }
//    }

////
//// Summary:
////     The type ItemBody.
//    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
//    public class ItemBody
//    {
//        public ItemBody()
//        {
//        }

//        //
//        // Summary:
//        //     Gets or sets contentType. The type of the content. Possible values are Text and
//        //     HTML.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "contentType",
//            Required = Required.Default)]
//        public BodyType? ContentType { get; set; }

//        //
//        // Summary:
//        //     Gets or sets content. The content of the item.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "content",
//            Required = Required.Default)]
//        public string Content { get; set; }

//        //
//        // Summary:
//        //     Gets or sets additional data.
//        [JsonExtensionData(ReadData = true)] public IDictionary<string, object> AdditionalData { get; set; }

//        //
//        // Summary:
//        //     Gets or sets @odata.type.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type",
//            Required = Required.Default)]
//        public string ODataType { get; set; }
//    }

////
//// Summary:
////     The type Recipient.

//    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
//    public class Recipient
//    {
//        public Recipient()
//        {
//        }

//        //
//        // Summary:
//        //     Gets or sets emailAddress. The recipient's email address.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "emailAddress",
//            Required = Required.Default)]
//        public EmailAddress EmailAddress { get; set; }

//        //
//        // Summary:
//        //     Gets or sets additional data.
//        [JsonExtensionData(ReadData = true)] public IDictionary<string, object> AdditionalData { get; set; }

//        //
//        // Summary:
//        //     Gets or sets @odata.type.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type",
//            Required = Required.Default)]
//        public string ODataType { get; set; }
//    }

////
//// Summary:
////     The type EmailAddress.
//    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
//    public class EmailAddress
//    {
//        public EmailAddress()
//        {
//        }

//        //
//        // Summary:
//        //     Gets or sets name. The display name of the person or entity.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name", Required = Required.Default)]
//        public string Name { get; set; }

//        //
//        // Summary:
//        //     Gets or sets address. The email address of the person or entity.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address",
//            Required = Required.Default)]
//        public string Address { get; set; }

//        //
//        // Summary:
//        //     Gets or sets additional data.
//        [JsonExtensionData(ReadData = true)] public IDictionary<string, object> AdditionalData { get; set; }

//        //
//        // Summary:
//        //     Gets or sets @odata.type.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type",
//            Required = Required.Default)]
//        public string ODataType { get; set; }
//    }

////
//// Summary:
////     The type FollowupFlag.
//    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
//    public class FollowupFlag
//    {
//        public FollowupFlag()
//        {
//        }

//        //
//        // Summary:
//        //     Gets or sets completedDateTime. The date and time that the follow-up was finished.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "completedDateTime",
//            Required = Required.Default)]
//        public DateTime CompletedDateTime { get; set; }

//        //
//        // Summary:
//        //     Gets or sets dueDateTime. The date and time that the follow-up is to be finished.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "dueDateTime",
//            Required = Required.Default)]
//        public DateTime DueDateTime { get; set; }

//        //
//        // Summary:
//        //     Gets or sets startDateTime. The date and time that the follow-up is to begin.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "startDateTime",
//            Required = Required.Default)]
//        public DateTime StartDateTime { get; set; }

//        //
//        // Summary:
//        //     Gets or sets flagStatus. The status for follow-up for an item. Possible values
//        //     are notFlagged, complete, and flagged.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flagStatus",
//            Required = Required.Default)]
//        public FollowupFlagStatus? FlagStatus { get; set; }

//        //
//        // Summary:
//        //     Gets or sets additional data.
//        [JsonExtensionData(ReadData = true)] public IDictionary<string, object> AdditionalData { get; set; }

//        //
//        // Summary:
//        //     Gets or sets @odata.type.
//        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type",
//            Required = Required.Default)]
//        public string ODataType { get; set; }
//    }
//}