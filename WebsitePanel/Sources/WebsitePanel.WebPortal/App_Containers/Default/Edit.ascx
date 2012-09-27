<%@ Control language="C#" AutoEventWireup="false" %>
<div class="EditContainer">
    <table class="Header" cellpadding="0" cellspacing="0">
        <tr>
            <td class="HeaderLeft"></td>
            <td class="HeaderTitle">
                <div class="HeaderIcon">
                    <asp:Image ID="imgModuleIcon" runat="server" ImageAlign="AbsMiddle" Width="48px" Height="48px" />
                </div>
                
                <asp:Label ID="lblModuleTitle" runat="server" CssClass="Head"></asp:Label>
            </td>
            <td class="HeaderRight"></td>
        </tr>
    </table>
    <div class="Content">
        <asp:PlaceHolder ID="ContentPane" runat="server"/>
    </div>
</div>