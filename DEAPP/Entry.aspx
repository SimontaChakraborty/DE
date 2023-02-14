<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="DEAPP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Student Entry</h2>
    <div class="container">
        <div class="row justify-content-center">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">            
                            <label class="form-label">Student Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">            
                            <label class="form-label">Class</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">            
                            <label class="form-label">Marks</label>
                            <asp:TextBox ID="txtMark" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">            
                            <label class="form-label">Subjects</label>
                            <asp:DropDownList ID="ddlSub" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">            
                            <asp:Button ID="txtbtn" runat="server" Text="Save" OnClick="txtbtn_Click" />        
                        </div>      
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="card-header bg-gradient-primary text-bg-primary">Student Information </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvStuInfo" CssClass="table table-bordered table-striped" runat="server" >
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
