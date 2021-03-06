// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: people.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Demo {

  /// <summary>Holder for reflection information generated from people.proto</summary>
  public static partial class PeopleReflection {

    #region Descriptor
    /// <summary>File descriptor for people.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PeopleReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxwZW9wbGUucHJvdG8SBGRlbW8iJgoGUGVvcGxlEhwKBnBlcnNvbhgBIAMo",
            "CzIMLmRlbW8uUGVyc29uIlUKBlBlcnNvbhIMCgRuYW1lGAEgASgJEh4KB2Fk",
            "ZHJlc3MYAiADKAsyDS5kZW1vLkFkZHJlc3MSDgoGbW9iaWxlGAMgAygJEg0K",
            "BWVtYWlsGAQgAygJIikKB0FkZHJlc3MSDgoGc3RyZWV0GAEgASgJEg4KBm51",
            "bWJlchgCIAEoBWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Demo.People), global::Demo.People.Parser, new[]{ "Person" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Demo.Person), global::Demo.Person.Parser, new[]{ "Name", "Address", "Mobile", "Email" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Demo.Address), global::Demo.Address.Parser, new[]{ "Street", "Number" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class People : pb::IMessage<People> {
    private static readonly pb::MessageParser<People> _parser = new pb::MessageParser<People>(() => new People());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<People> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Demo.PeopleReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public People() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public People(People other) : this() {
      person_ = other.person_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public People Clone() {
      return new People(this);
    }

    /// <summary>Field number for the "person" field.</summary>
    public const int PersonFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Demo.Person> _repeated_person_codec
        = pb::FieldCodec.ForMessage(10, global::Demo.Person.Parser);
    private readonly pbc::RepeatedField<global::Demo.Person> person_ = new pbc::RepeatedField<global::Demo.Person>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Demo.Person> Person {
      get { return person_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as People);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(People other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!person_.Equals(other.person_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= person_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      person_.WriteTo(output, _repeated_person_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += person_.CalculateSize(_repeated_person_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(People other) {
      if (other == null) {
        return;
      }
      person_.Add(other.person_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            person_.AddEntriesFrom(input, _repeated_person_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class Person : pb::IMessage<Person> {
    private static readonly pb::MessageParser<Person> _parser = new pb::MessageParser<Person>(() => new Person());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Person> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Demo.PeopleReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Person() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Person(Person other) : this() {
      name_ = other.name_;
      address_ = other.address_.Clone();
      mobile_ = other.mobile_.Clone();
      email_ = other.email_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Person Clone() {
      return new Person(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Demo.Address> _repeated_address_codec
        = pb::FieldCodec.ForMessage(18, global::Demo.Address.Parser);
    private readonly pbc::RepeatedField<global::Demo.Address> address_ = new pbc::RepeatedField<global::Demo.Address>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Demo.Address> Address {
      get { return address_; }
    }

    /// <summary>Field number for the "mobile" field.</summary>
    public const int MobileFieldNumber = 3;
    private static readonly pb::FieldCodec<string> _repeated_mobile_codec
        = pb::FieldCodec.ForString(26);
    private readonly pbc::RepeatedField<string> mobile_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Mobile {
      get { return mobile_; }
    }

    /// <summary>Field number for the "email" field.</summary>
    public const int EmailFieldNumber = 4;
    private static readonly pb::FieldCodec<string> _repeated_email_codec
        = pb::FieldCodec.ForString(34);
    private readonly pbc::RepeatedField<string> email_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Email {
      get { return email_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Person);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Person other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if(!address_.Equals(other.address_)) return false;
      if(!mobile_.Equals(other.mobile_)) return false;
      if(!email_.Equals(other.email_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      hash ^= address_.GetHashCode();
      hash ^= mobile_.GetHashCode();
      hash ^= email_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      address_.WriteTo(output, _repeated_address_codec);
      mobile_.WriteTo(output, _repeated_mobile_codec);
      email_.WriteTo(output, _repeated_email_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      size += address_.CalculateSize(_repeated_address_codec);
      size += mobile_.CalculateSize(_repeated_mobile_codec);
      size += email_.CalculateSize(_repeated_email_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Person other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      address_.Add(other.address_);
      mobile_.Add(other.mobile_);
      email_.Add(other.email_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            address_.AddEntriesFrom(input, _repeated_address_codec);
            break;
          }
          case 26: {
            mobile_.AddEntriesFrom(input, _repeated_mobile_codec);
            break;
          }
          case 34: {
            email_.AddEntriesFrom(input, _repeated_email_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class Address : pb::IMessage<Address> {
    private static readonly pb::MessageParser<Address> _parser = new pb::MessageParser<Address>(() => new Address());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Address> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Demo.PeopleReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Address() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Address(Address other) : this() {
      street_ = other.street_;
      number_ = other.number_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Address Clone() {
      return new Address(this);
    }

    /// <summary>Field number for the "street" field.</summary>
    public const int StreetFieldNumber = 1;
    private string street_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Street {
      get { return street_; }
      set {
        street_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "number" field.</summary>
    public const int NumberFieldNumber = 2;
    private int number_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Number {
      get { return number_; }
      set {
        number_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Address);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Address other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Street != other.Street) return false;
      if (Number != other.Number) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Street.Length != 0) hash ^= Street.GetHashCode();
      if (Number != 0) hash ^= Number.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Street.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Street);
      }
      if (Number != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Number);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Street.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Street);
      }
      if (Number != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Number);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Address other) {
      if (other == null) {
        return;
      }
      if (other.Street.Length != 0) {
        Street = other.Street;
      }
      if (other.Number != 0) {
        Number = other.Number;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Street = input.ReadString();
            break;
          }
          case 16: {
            Number = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
