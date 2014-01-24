﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payroll.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Payroll")]
	public partial class PayrollDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEmployee(Employee instance);
    partial void UpdateEmployee(Employee instance);
    partial void DeleteEmployee(Employee instance);
    partial void InsertEmployeeAddress(EmployeeAddress instance);
    partial void UpdateEmployeeAddress(EmployeeAddress instance);
    partial void DeleteEmployeeAddress(EmployeeAddress instance);
    #endregion
		
		public PayrollDataContext() : 
				base(global::Payroll.DataAccess.Properties.Settings.Default.PayrollConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PayrollDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PayrollDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PayrollDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PayrollDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Employee> Employees
		{
			get
			{
				return this.GetTable<Employee>();
			}
		}
		
		public System.Data.Linq.Table<EmployeeAddress> EmployeeAddresses
		{
			get
			{
				return this.GetTable<EmployeeAddress>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employee")]
	public partial class Employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _EmployeeNumber;
		
		private string _Title;
		
		private string _FirstName;
		
		private string _MiddleName;
		
		private string _LastName;
		
		private int _Age;
		
		private System.DateTime _Birthdate;
		
		private char _Sex;
		
		private string _CivilStatus;
		
		private string _HomePhone;
		
		private string _MobilePhone;
		
		private string _Email;
		
		private System.Nullable<System.Guid> _PresentHomeAddressId;
		
		private string _DepartmentCode;
		
		private string _PositionCode;
		
		private string _TaxStatusCode;
		
		private System.DateTime _HireDate;
		
		private string _EmployementTypeCode;
		
		private int _SSSNumber;
		
		private int _TINNumber;
		
		private System.Nullable<int> _PagIbigNumber;
		
		private System.Nullable<int> _PhilHealthNumber;
		
		private string _SalaryRate;
		
		private decimal _CurrentSalary;
		
		private string _BankNameCode;
		
		private System.Nullable<int> _AccountNumber;
		
		private string _EmployeeStatus;
		
		private bool _IsDeleted;
		
		private EntitySet<EmployeeAddress> _EmployeeAddresses;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnEmployeeNumberChanging(int value);
    partial void OnEmployeeNumberChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnAgeChanging(int value);
    partial void OnAgeChanged();
    partial void OnBirthdateChanging(System.DateTime value);
    partial void OnBirthdateChanged();
    partial void OnSexChanging(char value);
    partial void OnSexChanged();
    partial void OnCivilStatusChanging(string value);
    partial void OnCivilStatusChanged();
    partial void OnHomePhoneChanging(string value);
    partial void OnHomePhoneChanged();
    partial void OnMobilePhoneChanging(string value);
    partial void OnMobilePhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPresentHomeAddressIdChanging(System.Nullable<System.Guid> value);
    partial void OnPresentHomeAddressIdChanged();
    partial void OnDepartmentCodeChanging(string value);
    partial void OnDepartmentCodeChanged();
    partial void OnPositionCodeChanging(string value);
    partial void OnPositionCodeChanged();
    partial void OnTaxStatusCodeChanging(string value);
    partial void OnTaxStatusCodeChanged();
    partial void OnHireDateChanging(System.DateTime value);
    partial void OnHireDateChanged();
    partial void OnEmployementTypeCodeChanging(string value);
    partial void OnEmployementTypeCodeChanged();
    partial void OnSSSNumberChanging(int value);
    partial void OnSSSNumberChanged();
    partial void OnTINNumberChanging(int value);
    partial void OnTINNumberChanged();
    partial void OnPagIbigNumberChanging(System.Nullable<int> value);
    partial void OnPagIbigNumberChanged();
    partial void OnPhilHealthNumberChanging(System.Nullable<int> value);
    partial void OnPhilHealthNumberChanged();
    partial void OnSalaryRateChanging(string value);
    partial void OnSalaryRateChanged();
    partial void OnCurrentSalaryChanging(decimal value);
    partial void OnCurrentSalaryChanged();
    partial void OnBankNameCodeChanging(string value);
    partial void OnBankNameCodeChanged();
    partial void OnAccountNumberChanging(System.Nullable<int> value);
    partial void OnAccountNumberChanged();
    partial void OnEmployeeStatusChanging(string value);
    partial void OnEmployeeStatusChanged();
    partial void OnIsDeletedChanging(bool value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public Employee()
		{
			this._EmployeeAddresses = new EntitySet<EmployeeAddress>(new Action<EmployeeAddress>(this.attach_EmployeeAddresses), new Action<EmployeeAddress>(this.detach_EmployeeAddresses));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeNumber", DbType="Int NOT NULL")]
		public int EmployeeNumber
		{
			get
			{
				return this._EmployeeNumber;
			}
			set
			{
				if ((this._EmployeeNumber != value))
				{
					this.OnEmployeeNumberChanging(value);
					this.SendPropertyChanging();
					this._EmployeeNumber = value;
					this.SendPropertyChanged("EmployeeNumber");
					this.OnEmployeeNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(250)")]
		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				if ((this._MiddleName != value))
				{
					this.OnMiddleNameChanging(value);
					this.SendPropertyChanging();
					this._MiddleName = value;
					this.SendPropertyChanged("MiddleName");
					this.OnMiddleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="Date NOT NULL")]
		public System.DateTime Birthdate
		{
			get
			{
				return this._Birthdate;
			}
			set
			{
				if ((this._Birthdate != value))
				{
					this.OnBirthdateChanging(value);
					this.SendPropertyChanging();
					this._Birthdate = value;
					this.SendPropertyChanged("Birthdate");
					this.OnBirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Char(1) NOT NULL")]
		public char Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CivilStatus", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CivilStatus
		{
			get
			{
				return this._CivilStatus;
			}
			set
			{
				if ((this._CivilStatus != value))
				{
					this.OnCivilStatusChanging(value);
					this.SendPropertyChanging();
					this._CivilStatus = value;
					this.SendPropertyChanged("CivilStatus");
					this.OnCivilStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HomePhone", DbType="NVarChar(250)")]
		public string HomePhone
		{
			get
			{
				return this._HomePhone;
			}
			set
			{
				if ((this._HomePhone != value))
				{
					this.OnHomePhoneChanging(value);
					this.SendPropertyChanging();
					this._HomePhone = value;
					this.SendPropertyChanged("HomePhone");
					this.OnHomePhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MobilePhone", DbType="NVarChar(250)")]
		public string MobilePhone
		{
			get
			{
				return this._MobilePhone;
			}
			set
			{
				if ((this._MobilePhone != value))
				{
					this.OnMobilePhoneChanging(value);
					this.SendPropertyChanging();
					this._MobilePhone = value;
					this.SendPropertyChanged("MobilePhone");
					this.OnMobilePhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(250)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PresentHomeAddressId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> PresentHomeAddressId
		{
			get
			{
				return this._PresentHomeAddressId;
			}
			set
			{
				if ((this._PresentHomeAddressId != value))
				{
					this.OnPresentHomeAddressIdChanging(value);
					this.SendPropertyChanging();
					this._PresentHomeAddressId = value;
					this.SendPropertyChanged("PresentHomeAddressId");
					this.OnPresentHomeAddressIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartmentCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DepartmentCode
		{
			get
			{
				return this._DepartmentCode;
			}
			set
			{
				if ((this._DepartmentCode != value))
				{
					this.OnDepartmentCodeChanging(value);
					this.SendPropertyChanging();
					this._DepartmentCode = value;
					this.SendPropertyChanged("DepartmentCode");
					this.OnDepartmentCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PositionCode
		{
			get
			{
				return this._PositionCode;
			}
			set
			{
				if ((this._PositionCode != value))
				{
					this.OnPositionCodeChanging(value);
					this.SendPropertyChanging();
					this._PositionCode = value;
					this.SendPropertyChanged("PositionCode");
					this.OnPositionCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaxStatusCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TaxStatusCode
		{
			get
			{
				return this._TaxStatusCode;
			}
			set
			{
				if ((this._TaxStatusCode != value))
				{
					this.OnTaxStatusCodeChanging(value);
					this.SendPropertyChanging();
					this._TaxStatusCode = value;
					this.SendPropertyChanged("TaxStatusCode");
					this.OnTaxStatusCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HireDate", DbType="Date NOT NULL")]
		public System.DateTime HireDate
		{
			get
			{
				return this._HireDate;
			}
			set
			{
				if ((this._HireDate != value))
				{
					this.OnHireDateChanging(value);
					this.SendPropertyChanging();
					this._HireDate = value;
					this.SendPropertyChanged("HireDate");
					this.OnHireDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployementTypeCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EmployementTypeCode
		{
			get
			{
				return this._EmployementTypeCode;
			}
			set
			{
				if ((this._EmployementTypeCode != value))
				{
					this.OnEmployementTypeCodeChanging(value);
					this.SendPropertyChanging();
					this._EmployementTypeCode = value;
					this.SendPropertyChanged("EmployementTypeCode");
					this.OnEmployementTypeCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SSSNumber", DbType="Int NOT NULL")]
		public int SSSNumber
		{
			get
			{
				return this._SSSNumber;
			}
			set
			{
				if ((this._SSSNumber != value))
				{
					this.OnSSSNumberChanging(value);
					this.SendPropertyChanging();
					this._SSSNumber = value;
					this.SendPropertyChanged("SSSNumber");
					this.OnSSSNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TINNumber", DbType="Int NOT NULL")]
		public int TINNumber
		{
			get
			{
				return this._TINNumber;
			}
			set
			{
				if ((this._TINNumber != value))
				{
					this.OnTINNumberChanging(value);
					this.SendPropertyChanging();
					this._TINNumber = value;
					this.SendPropertyChanged("TINNumber");
					this.OnTINNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PagIbigNumber", DbType="Int")]
		public System.Nullable<int> PagIbigNumber
		{
			get
			{
				return this._PagIbigNumber;
			}
			set
			{
				if ((this._PagIbigNumber != value))
				{
					this.OnPagIbigNumberChanging(value);
					this.SendPropertyChanging();
					this._PagIbigNumber = value;
					this.SendPropertyChanged("PagIbigNumber");
					this.OnPagIbigNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhilHealthNumber", DbType="Int")]
		public System.Nullable<int> PhilHealthNumber
		{
			get
			{
				return this._PhilHealthNumber;
			}
			set
			{
				if ((this._PhilHealthNumber != value))
				{
					this.OnPhilHealthNumberChanging(value);
					this.SendPropertyChanging();
					this._PhilHealthNumber = value;
					this.SendPropertyChanged("PhilHealthNumber");
					this.OnPhilHealthNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalaryRate", DbType="NVarChar(50)")]
		public string SalaryRate
		{
			get
			{
				return this._SalaryRate;
			}
			set
			{
				if ((this._SalaryRate != value))
				{
					this.OnSalaryRateChanging(value);
					this.SendPropertyChanging();
					this._SalaryRate = value;
					this.SendPropertyChanged("SalaryRate");
					this.OnSalaryRateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentSalary", DbType="Decimal(18,2) NOT NULL")]
		public decimal CurrentSalary
		{
			get
			{
				return this._CurrentSalary;
			}
			set
			{
				if ((this._CurrentSalary != value))
				{
					this.OnCurrentSalaryChanging(value);
					this.SendPropertyChanging();
					this._CurrentSalary = value;
					this.SendPropertyChanged("CurrentSalary");
					this.OnCurrentSalaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankNameCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string BankNameCode
		{
			get
			{
				return this._BankNameCode;
			}
			set
			{
				if ((this._BankNameCode != value))
				{
					this.OnBankNameCodeChanging(value);
					this.SendPropertyChanging();
					this._BankNameCode = value;
					this.SendPropertyChanged("BankNameCode");
					this.OnBankNameCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="Int")]
		public System.Nullable<int> AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeStatus", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EmployeeStatus
		{
			get
			{
				return this._EmployeeStatus;
			}
			set
			{
				if ((this._EmployeeStatus != value))
				{
					this.OnEmployeeStatusChanging(value);
					this.SendPropertyChanging();
					this._EmployeeStatus = value;
					this.SendPropertyChanged("EmployeeStatus");
					this.OnEmployeeStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit NOT NULL")]
		public bool IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_EmployeeAddress", Storage="_EmployeeAddresses", ThisKey="Id", OtherKey="EmployeeId")]
		public EntitySet<EmployeeAddress> EmployeeAddresses
		{
			get
			{
				return this._EmployeeAddresses;
			}
			set
			{
				this._EmployeeAddresses.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_EmployeeAddresses(EmployeeAddress entity)
		{
			this.SendPropertyChanging();
			entity.Employee = this;
		}
		
		private void detach_EmployeeAddresses(EmployeeAddress entity)
		{
			this.SendPropertyChanging();
			entity.Employee = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmployeeAddress")]
	public partial class EmployeeAddress : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _EmployeeId;
		
		private string _AddressTypeCode;
		
		private string _Address;
		
		private string _CityMun;
		
		private string _ProvState;
		
		private string _CountryCode;
		
		private string _ZipCode;
		
		private long _IsDeleted;
		
		private EntityRef<Employee> _Employee;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnEmployeeIdChanging(System.Guid value);
    partial void OnEmployeeIdChanged();
    partial void OnAddressTypeCodeChanging(string value);
    partial void OnAddressTypeCodeChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnCityMunChanging(string value);
    partial void OnCityMunChanged();
    partial void OnProvStateChanging(string value);
    partial void OnProvStateChanged();
    partial void OnCountryCodeChanging(string value);
    partial void OnCountryCodeChanged();
    partial void OnZipCodeChanging(string value);
    partial void OnZipCodeChanged();
    partial void OnIsDeletedChanging(long value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public EmployeeAddress()
		{
			this._Employee = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid EmployeeId
		{
			get
			{
				return this._EmployeeId;
			}
			set
			{
				if ((this._EmployeeId != value))
				{
					if (this._Employee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIdChanging(value);
					this.SendPropertyChanging();
					this._EmployeeId = value;
					this.SendPropertyChanged("EmployeeId");
					this.OnEmployeeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressTypeCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string AddressTypeCode
		{
			get
			{
				return this._AddressTypeCode;
			}
			set
			{
				if ((this._AddressTypeCode != value))
				{
					this.OnAddressTypeCodeChanging(value);
					this.SendPropertyChanging();
					this._AddressTypeCode = value;
					this.SendPropertyChanged("AddressTypeCode");
					this.OnAddressTypeCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityMun", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string CityMun
		{
			get
			{
				return this._CityMun;
			}
			set
			{
				if ((this._CityMun != value))
				{
					this.OnCityMunChanging(value);
					this.SendPropertyChanging();
					this._CityMun = value;
					this.SendPropertyChanged("CityMun");
					this.OnCityMunChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProvState", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ProvState
		{
			get
			{
				return this._ProvState;
			}
			set
			{
				if ((this._ProvState != value))
				{
					this.OnProvStateChanging(value);
					this.SendPropertyChanging();
					this._ProvState = value;
					this.SendPropertyChanged("ProvState");
					this.OnProvStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryCode", DbType="NVarChar(50)")]
		public string CountryCode
		{
			get
			{
				return this._CountryCode;
			}
			set
			{
				if ((this._CountryCode != value))
				{
					this.OnCountryCodeChanging(value);
					this.SendPropertyChanging();
					this._CountryCode = value;
					this.SendPropertyChanged("CountryCode");
					this.OnCountryCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZipCode", DbType="NVarChar(50)")]
		public string ZipCode
		{
			get
			{
				return this._ZipCode;
			}
			set
			{
				if ((this._ZipCode != value))
				{
					this.OnZipCodeChanging(value);
					this.SendPropertyChanging();
					this._ZipCode = value;
					this.SendPropertyChanged("ZipCode");
					this.OnZipCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="BigInt NOT NULL")]
		public long IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_EmployeeAddress", Storage="_Employee", ThisKey="EmployeeId", OtherKey="Id", IsForeignKey=true)]
		public Employee Employee
		{
			get
			{
				return this._Employee.Entity;
			}
			set
			{
				Employee previousValue = this._Employee.Entity;
				if (((previousValue != value) 
							|| (this._Employee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee.Entity = null;
						previousValue.EmployeeAddresses.Remove(this);
					}
					this._Employee.Entity = value;
					if ((value != null))
					{
						value.EmployeeAddresses.Add(this);
						this._EmployeeId = value.Id;
					}
					else
					{
						this._EmployeeId = default(System.Guid);
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
