using System;
using System.Collections.Generic;

namespace DesignPaternBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new FirstBuilder()
                .SetSender("@sdlfkj")
                .SetReceiver("2@s;dlfk;sldkf")
                .NextBuilder()
                .setText("gjldkj")
                .Build();
        }

        public class FirstBuilder
        {
            public SecondBuilder SetSender(string email)
            {
                if (email.Contains("@"))
                    throw new Exception("not valid email");
                return new SecondBuilder {sender = email};
            }
        }
    }

    internal class SecondBuilder
    {
        public List<string> receiver = new List<string>();
        public string sender { get; set; }

        public SecondBuilder SetReceiver(string email)
        {
            if (email.Contains("@"))
                throw new Exception("not valid email");
            receiver.Add(email);
            return this;
        }

        public ThirdBuilder NextBuilder()
        {
            if (receiver.Count > 0) return new ThirdBuilder {sender = sender, receiver = receiver};

            throw new Exception("receiver count is 0");
        }
    }

    internal class ThirdBuilder
    {
        public List<string> receiver;
        private string text;
        public string sender { get; set; }

        public ThirdBuilder setText(string text)
        {
            this.text = text;
            return this;
        }

        public Mail Build()
        {
            if (text is null)
                throw new Exception("");
            return new Mail {sender = sender, receiver = receiver, text = text};
        }
    }

    internal class Mail
    {
        public List<string> receiver { get; set; }
        public string sender { get; set; }
        public string text { get; set; }
    }
}