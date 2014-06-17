﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Serialization
{
    using System;
    using Util;

    public class StaticMessageTypeConverter :
        IMessageTypeConverter
    {
        readonly object _message;
        readonly Type _messageType;

        public StaticMessageTypeConverter( object message)
        {
            _message = message;
            _messageType = message.GetType();
        }

        public bool Contains(Type messageType)
        {
            return messageType.IsAssignableFrom(_messageType);
        }

        public bool TryConvert<T>(out T message) where T : class
        {
            if (typeof(T).IsAssignableFrom(_messageType))
            {
                message = (T)_message;
                return true;
            }

            message = null;
            return false;
        }
    }
}