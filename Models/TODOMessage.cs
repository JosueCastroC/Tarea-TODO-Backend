﻿namespace TodoApi.Models
{
    public class TODOMessage
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }



    }
}
