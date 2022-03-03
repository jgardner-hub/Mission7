﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book bok, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == bok.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bok,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }

        }

        public virtual void RemoveItem(Book bok)
        {
            Items.RemoveAll(x => x.Book.BookId == bok.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }


        public double CalculateTotal() //maybe put an int bookId here???
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price); //this needs to be fixed 

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
