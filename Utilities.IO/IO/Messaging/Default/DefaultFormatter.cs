﻿/*
Copyright (c) 2014 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using Utilities.DataTypes;
using Utilities.IO.Messaging.Interfaces;

namespace Utilities.IO.Messaging.Default
{
    /// <summary>
    /// Default formatter if one isn't found
    /// </summary>
    public class DefaultFormatter : IFormatter
    {
        /// <summary>
        /// Name of the formatter
        /// </summary>
        public string Name { get { return "Default"; } }

        /// <summary>
        /// Formats the message
        /// </summary>
        /// <param name="Message">Message to format</param>
        /// <param name="Model">Model object used to format the message</param>
        /// <returns>The formatted message</returns>
        public void Format<T>(IMessage Message, T Model)
        {
            if (Message == null)
                throw new ArgumentNullException(nameof(Message));
            if (Model == null)
                throw new ArgumentNullException(nameof(Model));
            if (string.IsNullOrEmpty(Message.Body) || Model.Is<string>())
                Message.Body = Model.ToString();
            else
                Message.Body = Message.Body.ToString(Model);
        }
    }
}