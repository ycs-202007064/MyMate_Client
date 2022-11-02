﻿using ClientModules.Extensions;
using ClientModules.Models;
using ClientModules.Models.Chat;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModules.Containers
{
    public class ChatroomContainer
    {
        public List<MdlChatroom> Items = new();

        public event distribute? dataDistributedEvent;
        public event distribute DataDistributedEvent
        {
            add => dataDistributedEvent += value;
            remove => dataDistributedEvent -= value;
        }

        public event error? errorEvent;
        public event error ErrorEvent
        {
            add => errorEvent += value;
            remove => errorEvent -= value;
        }

        public void AddOrUpdate(MdlChatroom v)
        {
            if (v.nullCheck() == true)
            {
                if (this.errorEvent != null)
                    this.errorEvent();
                return;
            }

            if (Items.Count == 0)
            {
                Items.Add(v);
                if (this.dataDistributedEvent != null)
                    this.dataDistributedEvent();
                return;
            }

            int i = Items.FindIndex(MdlChatroom => MdlChatroom.Code == v.Code);

            if (i != -1)
            {
                Items.Insert(i, v);
                Items.RemoveAt(i + 1);
                if (this.dataDistributedEvent != null)
                    this.dataDistributedEvent();
            }
        }
    }
}