﻿namespace ReviewSystem.Dto.Get
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int ReviewerId { get; set; }

    }
}