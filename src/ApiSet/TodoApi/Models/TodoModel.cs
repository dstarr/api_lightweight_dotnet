﻿namespace TodoApi.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }

}
