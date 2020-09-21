/**  Class Info。
* DogTypeModel.cs
*
* 功 能： N/A
* 类 名： DogTypeModel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/16/2020 9:17:38 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
namespace DogApi.Model
{
	/// <summary>
	/// DogTypeModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DogTypeModel
	{
		public DogTypeModel()
		{}
		#region Model
		private int _typeid;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public int typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

