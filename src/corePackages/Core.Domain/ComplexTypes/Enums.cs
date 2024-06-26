﻿using System.ComponentModel.DataAnnotations;

namespace Core.Domain.ComplexTypes.Enums
{

    public enum RecordStatu
    {
        None = 0,
        Active = 1,
        Passive = 2,
    }

    public enum FileType
    {
        None,
        Xls,
        Xlsx,
        Doc,
        Pps,
        Pdf,
        Img,
        Mp4
    }


    public enum CultureType
    {
        None = 0,
        [Display(Name = "en-US")]
        US = 1,
        [Display(Name = "tr-TR")]
        TR = 2,

    }

    public enum AuthenticatorType
    {
        None = 0,
        Email = 1,
        Otp = 2
    }

    public enum ConfirmationTypes
    {
        None = 0
    }

    public enum NotificationType
    {
        None = 0,
        Comment = 1,
        CommentLike = 2,
        PostLike = 3,
        Subscription = 4,
        Achievement = 5,
        Mention = 6,
        PostAnnouncement = 7,
        DailyTip = 8,
        DraftReminder = 9
    }

    public enum VoteType
    {
        None = 0,
        Upvote = 1,
        Downvote = -1
    }

    public enum ArticleReportType
    {
        None = 0,
        NotAbout = 1,
        BrokenLink = 2,
        Clickbait = 3,
        LowQuality = 4,
        NSFW = 5,
        Other = 6
    }
}
