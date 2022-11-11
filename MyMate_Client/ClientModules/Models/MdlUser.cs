﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Protocol;

namespace ClientModules.Models
{
	public class MdlUser
	{
		//유저 코드
		public int Code { get; set; }
		//유저 실제 이름
		public string Name { get; set; }
		//유저 별명
		public string Username { get; set; }
		//유저 상태
		//public int Status { get; set; }
		//유저 E-mail 주소
		public string Email { get; set; }
		//유저 연락처
		public string PhoneNumber { get; set; }
		//유저 자기소개
		public string Introduction { get; set; }
		//최근 패킷 받은 시간
		public DateTime RecentTime { get; set; }

        public MdlUser(int code, string name, string username, string email, string phonenumber, string introduce)
        {
			this.Code = code;
			this.Name = name;
			this.Username = username;
			this.Email = email;
			this.PhoneNumber = phonenumber;
			this.Introduction = introduce;
        }

		public MdlUser() { }
        public MdlUser(UserProtocol.USER user)
		{
            this.Code = user.userCode;
            this.Name = user.name;
            this.Username = user.nickname;
            this.Email = user.email;
            this.PhoneNumber = user.phone;
            this.Introduction = user.content;
			//this.RecentTime = user.recentTime;
        }

        public bool nullCheck()
		{
			return Code == 0 ? true : false;
		}
	}
}