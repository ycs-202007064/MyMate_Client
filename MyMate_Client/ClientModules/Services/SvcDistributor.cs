using Client_to_Server;
using Protocol;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RcdResult = System.Collections.Generic.KeyValuePair<byte, object?>;

using ClientModules.Containers;
using ClientModules.Extensions;
using ClientModules.Models;

namespace ClientModules.Services
{

	public sealed class SvcDistributor
	{
		private List<byte>? bytes;
		private RcdResult result;

		// 싱글턴 구현
		// Distributor.Instance.~~~로 접근합니다.
		// 클래스 안에 static 멤버 속성은 프로그램 메모리 적재 시에 구성되고
		private static SvcDistributor? instance;
		public static SvcDistributor Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SvcDistributor();
					//Console.WriteLine("distributor 실행됨");
				}
				return instance;
			}
		}


		private SvcDistributor()
		{
			// 수신 큐에 KeyValuePair가 들어오면 읽어서 해당 오브젝트 큐로 전송하도록 taskDistributor 이벤트 등록

			// 이벤트 정리
			// 1. 대리자 선언
			// 2. 대리자 형식 이벤트 속성 선언
			// 3. 작업을 수행할 객체에서 대리자 형식 이벤트에 메서드 추가
			// 4. 이벤트 호출하면 해당 메서드가 실행됨

			Server.Instance.ReceiveEvent += taskDistributor;
		}

		private static void taskDistributor()
		{
			if (!Server.Instance.IsEmpty())
			{
				// 데이터를 읽어옴
				Server.Instance.Receive(out Instance.bytes);
				Instance.result = Converter.Convert(Instance.bytes);

				// 읽어온 데이터가 없다면 Continue
				if (null != Instance.result.Value)
#pragma warning disable CS8620 // 참조 형식의 null 허용 여부 차이로 인해 매개 변수에 대해 인수를 사용할 수 없습니다.
					estimateObject(Instance.result);
#pragma warning restore CS8620 // null check if문을 사용했으므로/정상적인 값이 전송되는 경우만 고려하므로 무시함
			}
		}

		private static void estimateObject(KeyValuePair<byte, object> temp)
		{
			/*
			switch (temp.Key)
			{
				case Protocol.DataType.USER_INFO:
					{
						UserInfoProtocol.User? userinfo;
						userinfo = temp.Value as UserInfoProtocol.User;

						MdlUser d = new(userinfo);

						//유저코드/밸류 순으로 딕셔너리에 저장
						Users.AddOrUpdate(d.Code, d);

						//Enumerable.Where 사용법
						//IEnumerable<MdlUserInfo> query = DisplayUser.Dictionary.Values.Where(MdlUserInfo => MdlUserInfo.UserCode == 0);
						IEnumerable<MdlUser> query = Users.Dictionary.Values;
						if (query != null)
							foreach (MdlUser _temp in query)
							{
								Console.WriteLine("UserCode:" + _temp.UserCode);
								Console.WriteLine("Name:" + _temp.Name);
								Console.WriteLine("ID:" + _temp.ID);
								Console.WriteLine("Nickname:" + _temp.Nick);
								Console.WriteLine("PhoneNumber:" + _temp.PhoneNumber);
							}
					}
					break;

				default:
					Console.WriteLine("알 수 없는 데이터를 수신하고 딕셔너리에는 저장하지 않았습니다.");
					break;
			}
			*/
		}
	}
}
