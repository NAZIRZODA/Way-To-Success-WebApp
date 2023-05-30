﻿namespace WTSuccess.Domain.Models.ExamScene
{
    public class Answer : EntityBase
    {
        public string Text { get; set; }

        public virtual Question? Question { get; set; }

        public ulong QuestionId { get; set; }

        public bool isCorrect { get; set; }
    }
}