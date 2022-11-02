﻿using ClientModules.Extensions;
using ClientModules.Models;
using ClientModules.Services;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModules.Containers
{
    public class UserContainer : IContainer
    {
        public int MyUserCode { get; set; }
        public ConcurrentDictionary<int, MdlUser> Dict = new();

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

        private static UserContainer? instance;
        public static UserContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserContainer();
                }
                return instance;
            }
        }
        public void AddOrUpdate(int k, MdlUser v)
        {
            if (v.nullCheck() == false)
            {
                this.Dict.AddOrUpdate(k, v);
                if (this.dataDistributedEvent != null)
                    this.dataDistributedEvent();
            }
            else
            {
                if (this.errorEvent != null)
                    this.errorEvent();
            }
        }
    }
}
