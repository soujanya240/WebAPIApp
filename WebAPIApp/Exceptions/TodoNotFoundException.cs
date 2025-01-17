﻿using System;
namespace WebAPIApp.Exceptions
{
   
        public class TodoNotFoundException : Exception
        {
            public TodoNotFoundException(int id)
                : base($"Todo item with ID {id} was not found.")
            {
            }
        }
   
}
