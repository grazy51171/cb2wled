using System.Text.Json.Serialization;

namespace cb2wled.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "method")]
    [JsonDerivedType(typeof(TipEvent), typeDiscriminator: "tip")]
    [JsonDerivedType(typeof(BroadcastStartEvent), typeDiscriminator: "broadcastStart")]
    [JsonDerivedType(typeof(BroadcastStopEvent), typeDiscriminator: "broadcastStop")]
    [JsonDerivedType(typeof(ChatMessageEvent), typeDiscriminator: "chatMessage")]
    [JsonDerivedType(typeof(FanclubJoinEvent), typeDiscriminator: "fanclubJoin")]
    [JsonDerivedType(typeof(FollowEvent), typeDiscriminator: "follow")]
    [JsonDerivedType(typeof(PrivateMessageEvent), typeDiscriminator: "privateMessage")]
    [JsonDerivedType(typeof(RoomSubjectChangeEvent), typeDiscriminator: "roomSubjectChange")]
    [JsonDerivedType(typeof(UnfollowEvent), typeDiscriminator: "unfollow")]
    [JsonDerivedType(typeof(UserEnterEvent), typeDiscriminator: "userEnter")]
    [JsonDerivedType(typeof(UserLeaveEvent), typeDiscriminator: "userLeave")]
    public class Event
    {
        public string Id { get; set; } = string.Empty;
    }

    public class Event<T> : Event
    {
        public T? Object { get; set; } = default!;
    }



    public class BroadcastStartEvent : Event<BroadcastDetail>
    {
    }

    public class BroadcastStopEvent : Event<BroadcastDetail>
    {
    }

    public class ChatMessageEvent : Event<ChatMessageDetail>
    {
    }

    public class FanclubJoinEvent : Event<UserDetail>
    {
    }

    public class FollowEvent : Event<UserDetail>
    {
    }

    public class MediaPurchaseEvent : Event<MediaPurchaseDetail>
    {
    }

    public class PrivateMessageEvent : Event<ChatMessageDetail>
    {
    }

    public class RoomSubjectChangeEvent : Event<RoomSubjectDetail>
    {
    }

    public class TipEvent : Event<TipDetail>
    {
    }

    public class UnfollowEvent : Event<UserDetail>
    {
        
    }

    public class UserEnterEvent : Event<UserDetail>
    {
        
    }

    public class UserLeaveEvent : Event<UserDetail>
    {
        
    }

}