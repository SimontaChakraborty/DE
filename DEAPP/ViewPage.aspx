<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="DEAPP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>View Page</h2>

    <div class="container">
        <div class="row justify-content-center">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">            
                            <label class="form-label">Class</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
             
                    <div class="row">
                        <div class="col-md-6">            
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />        
                        </div>      
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="card-header bg-gradient-primary text-bg-primary">Student Result Information </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvSTInfo" CssClass="table table-bordered table-striped" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
