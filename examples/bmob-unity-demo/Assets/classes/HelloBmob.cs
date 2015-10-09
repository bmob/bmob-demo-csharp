using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System.Net;
using cn.bmob.json;
using cn.bmob.response;
using cn.bmob.Extensions;

public class HelloBmob : MonoBehaviour
{

		private static BmobUnity Bmob;

		// Use this for initialization
		void Start ()
		{
        // Bmob.initialize("4414150cb439afdf684d37dc184e0f9f", "e1deb317442129c125b228ddf78e5f22");
				BmobDebug.Register (print);
				BmobDebug.level = BmobDebug.Level.TRACE;
				Bmob = gameObject.GetComponent<BmobUnity> ();
		}

		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}
		}

		static String TABLENAME = "T_BMOB_API";

		public class BmobGameObject : BmobTable
		{
				public BmobInt score { get; set; }

				public String playerName { get; set; }

				public BmobBoolean cheatMode { get; set; }

				public override void readFields (BmobInput input)
				{
						base.readFields (input);

						this.score = input.getInt ("score");
						this.cheatMode = input.getBoolean ("cheatMode");
						this.playerName = input.getString ("playerName");
				}

				public override void write (BmobOutput output, Boolean all)
				{
						base.write (output, all);

						output.Put ("score", this.score);
						output.Put ("cheatMode", this.cheatMode);
						output.Put ("playerName", this.playerName);
				}
		}

		void createOpCallback ()
		{
				var data = new BmobGameObject ();
        
				System.Random rnd = new System.Random ();
				data.score = rnd.Next (-50, 170);
				data.playerName = "123";
				data.cheatMode = false;

				// /ok callback
//        Bmob.Create(TABLENAME, data, (resp, exception) =>
//        {
//            if(exception != null){
//                print("保存失败, 失败原因为： " + exception.Message);
//                return;
//            }
//
//            print("保存成功, @" + resp.createdAt);
//        });


		}

		void create ()
		{
				var data = new BmobGameObject ();
		
				System.Random rnd = new System.Random ();
				data.score = rnd.Next (-50, 170);
				data.playerName = "123";
				data.cheatMode = false;

				Bmob.Create (TABLENAME, data, 
				             (resp, exception) => {
								if (exception != null) {
									print ("保存失败, 失败原因为： " + exception.Message);
									return;
								}
								
								print ("保存成功, @" + resp.createdAt);
							}
				);
				//Bmob.CreateTaskAsync (TABLENAME, data);
		}

		void UpdateGame ()
		{
				BmobGameObject game = new BmobGameObject ();
				game.playerName = "pn_123";
        Bmob.Update (TABLENAME, "58b84a1e12", game, (resp, exception) =>
				{
						if (exception != null) {
								print ("保存失败, 失败原因为： " + exception.Message);
								return;
						}

						print ("保存成功, @" + resp.updatedAt);
				});
		}

		void DeleteGame ()
		{
        Bmob.Delete (TABLENAME, "58b84a1e12", (resp, exception) =>
				{
						if (exception != null) {
								print ("删除失败, 失败原因为： " + exception.Message);
								return;
						}

						print ("删除成功, @" + resp.msg);
				});
		}

		void GetGame ()
		{
        Bmob.Get<BmobGameObject> (TABLENAME, "58b84a1e12", (resp, exception) =>
				{
						if (exception != null) {
								print ("查询失败, 失败原因为： " + exception.Message);
								return;
						}

						BmobGameObject game = resp;
						print ("获取的对象为： " + toString (game));
				});
		}

		String toString (object obj)
		{ 
				//if (obj is IBmobWritable) {
				//		return JsonAdapter.JSON.ToJson ((IBmobWritable)obj); 
				//} else
						return JsonAdapter.JSON.ToDebugJsonString (obj);
		}

		void FindQuery ()
		{
				BmobQuery query = new BmobQuery ();
				query.WhereEqualTo ("playerName", "123");
				Bmob.Find<BmobGameObject> (TABLENAME, query, (resp, exception) =>
				{
						if (exception != null) {
								print ("查询失败, 失败原因为： " + exception.Message);
								return;
						}

						List<BmobGameObject> list = resp.results;
						foreach (var game in list) {
								print ("获取的对象为： " + toString (game));
						}
				});
		}

		void FindQueryWithCount ()
		{
				BmobQuery query = new BmobQuery ();
				query.WhereEqualTo ("playerName", "123");
				query.Count ();
				Bmob.Find<BmobGameObject> (TABLENAME, query, (resp, exception) =>
				{
						if (exception != null) {
								print ("查询失败, 失败原因为： " + exception.Message);
								return;
						}

						List<BmobGameObject> list = resp.results;
						BmobInt count = resp.count;
						print ("满足条件的对象个数为： " + count.Get ());
						foreach (var game in list) {
								print ("获取的对象为： " + toString (game));
						}
				});
		}

		// 如果程序需要为用户添加额外的字段，需要继承BmobUser
		public class MyBmobUser : BmobUser
		{
				public BmobInt life { get; set; }

				public BmobInt attack { get; set; }

				public override void write (BmobOutput output, bool all)
				{
						base.write (output, all);

						output.Put ("life", this.life);
						output.Put ("attack", this.attack);
				}

				public override void readFields (BmobInput input)
				{
						base.readFields (input);

						this.life = input.getInt ("life");
						this.attack = input.getInt ("attack");
				}
		}

		void Signup ()
		{
				MyBmobUser user = new MyBmobUser ();
				user.username = "test";
				user.password = "123456";
				user.email = "support@bmob.cn";
				user.life = 0;
				user.attack = 0;

				Bmob.Signup<MyBmobUser> (user, (resp, exception) =>
				{
						if (exception != null) {
								print ("注册失败, 失败原因为： " + exception.Message);
								return;
						}

						print ("注册成功");
				});
		}

		void Login ()
		{
				Bmob.Login<MyBmobUser> ("test", "123456", (resp, exception) => {
						if (exception != null) {
								print ("登录失败, 失败原因为： " + exception.Message);
								return;
						}
			
						print ("登录成功, @" + resp.username + "(" + resp.life + ")$[" + resp.sessionToken + "]");

						print ("登录成功, 当前用户对象Session： " + BmobUser.CurrentUser.sessionToken);
				});
		}

		void gotCurrentUser ()
		{
			print ("登录后用户： " + toString(BmobUser.CurrentUser));
		}

		void updateuser ()
		{
				Bmob.Login<MyBmobUser> ("test", "123456", (resp, ex) =>
				{
						print (resp.sessionToken);
						MyBmobUser u = new MyBmobUser ();
						u.attack = 1000;
						Bmob.UpdateUser (resp.objectId, u, resp.sessionToken, (updateResp, updateException) =>
						{
								if (updateException != null) {
										print ("保存失败, 失败原因为： " + updateException.Message);
										return;
								}
				
								print ("保存成功, @" + updateResp.updatedAt);
						});
				});
		}

	void findAllUser ()
	{

		BmobQuery query = new BmobQuery ();
		//query.WhereEqualTo ("playerName", "123");
		query.Count ();
		Bmob.Find<MyBmobUser> (MyBmobUser.TABLE, query, (resp, exception) =>
		                           {
			if (exception != null) {
				print ("查询失败, 失败原因为： " + exception.Message);
				return;
			}
			
			List<MyBmobUser> list = resp.results;
			BmobInt count = resp.count;
			print ("满足条件的对象个数为： " + count.Get ());
			foreach (var game in list) {
				print ("获取的对象为： " + toString (game));
			}
		});

	}

		void ResetPassword ()
		{
				Bmob.Reset ("support@bmob.cn", (resp, exception) => {
						if (exception != null) {
								print ("重置密码请求失败, 失败原因为： " + exception.Message);
								return;
						}
			
						print ("重置密码请求发送成功！");
				});
		}

		void FileUpload(){
		Bmob.FileUpload("E:\\winsegit\\bmob\\bmob-csharp\\bmob-demo-csharp\\examples\\bmob-unity-demo\\README.md", (resp, exception) => {
				if (exception != null) {
					print ("上传请求失败, 失败原因为： " + exception.Message);
					return;
				}
				
				print ("上传请求发送成功！" + toString (resp));
			});
		}

		void FindUser ()
		{
				BmobQuery query = new BmobQuery ();
				query.WhereEqualTo ("username", "test");
				Bmob.Find<MyBmobUser> (BmobUser.TABLE, query, (resp, exception) =>
				{
						if (exception != null) {
								print ("查询失败, 失败原因为： " + exception.Message);
								return;
						}
			
						List<MyBmobUser> list = resp.results;
						foreach (var user in list) {
								print ("获取的对象为： " + toString (user));
						}
				});
		}

		void endpoint ()
		{
				Bmob.Endpoint<Hashtable> ("test", (resp, exception) => {
						if (exception != null) {
								print ("查询失败, 失败原因为： " + exception.Message);
								return;
						}

						print ("返回对象为： " + resp);
				});
		}

		protected void WWWFormRequest ()
		{
				WWWForm form = new WWWForm ();
				form.AddBinaryData ("tab.text", new byte[]{0,1,2});
	
				if (form != null && form.headers.Count > 0) {
						var headers = new Hashtable (); // add content-type
						IDictionaryEnumerator formHeadersIterator = form.headers.GetEnumerator ();
						while (formHeadersIterator.MoveNext())
								headers.Add ((String)formHeadersIterator.Key, formHeadersIterator.Value);
				}
	
	    
		}

		void OnGUI ()
		{
				float scale = 2.0f;

				if (Application.platform == RuntimePlatform.IPhonePlayer) {
						scale = Screen.width / 320;
				}

				float btnWidth = 100 * scale;
				float btnHeight = 25 * scale;
				float btnTop = 10 * scale;
				GUI.skin.button.fontSize = Convert.ToInt32 (12 * scale);

				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "Create")) {
						create ();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "Update")) {
						UpdateGame ();
				}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "QueryAll")) {
						FindQuery ();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "QueryWithCount")) {
						FindQueryWithCount ();
				}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "Get")) {
						GetGame ();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "Delete")) {
						DeleteGame ();
				}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "Signup")) {
						Signup ();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "Login")) {
						Login ();
				}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "updateuser")) {
						updateuser ();
				}
				//if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "ResetPassword")) {
				//		ResetPassword ();
				//}
		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "FileUpload")) {
			FileUpload ();
		}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "FindUser")) {
						FindUser ();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "endpoint")) {
						endpoint ();
				}

				btnTop += btnHeight + 10 * scale;
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 - btnWidth, btnTop, btnWidth, btnHeight), "GotCurrentUser")) {
					gotCurrentUser();
				}
				if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2 + btnWidth, btnTop, btnWidth, btnHeight), "findAllUser")) {
					findAllUser();
				}


				
		}

}
