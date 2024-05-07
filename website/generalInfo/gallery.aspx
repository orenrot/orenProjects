<%@ Page Title="gallery" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var cnt = 0; //משתנה מונה שהתמונה לא תשתנה פעמיים בלחיצה
    var cnt2=0;
    function Back() {
        if (document.getElementById("mD").src != '/pic/220px-Dinosaurmovieposter.jpg' && document.getElementById("mD").src != '/pic/10.-Lady-and-the-Tramp.jpg' && cnt == 0) {
        //תנאי שיבדוק שהתמונה ב היא דמבו md
            document.getElementById("mD").src = '/pic/10.-Lady-and-the-Tramp.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("Z").src = '/pic/5.-Finding-Nemo.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("L").src = '/pic/4.-Toy-Story-31.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("T").src = '/pic/1.-The-Lion-King1.jpg'; //משנה את מקור התמונה/שינוי התמונה
            cnt++;//אם כן אז המשתנה מונה יעלה בעוד אחד  כדי שזה לא ישתנה שוב לאותה תמונה מבלי להפוך לתמונה אחרת
        }
        else {
            document.getElementById("mD").src = '/gifs/tumblr_inline_oybanyWRzo1uz3yzl_540.gif'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("Z").src = '/pic/Zootopia5669c94c462101.jpg'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("L").src = '/pic/the little mermaid.jpg'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("T").src = '/pic/treaure planet.jpeg'; //משנה את מקור התמונה/שינוי התמונה
                cnt =0;//אם אחרת כלומר המשתנה מונה גדל אז התמונה צריכה להשתנות פעם הבאה לתנאי הראשון איפוס זה מאפשר לחזור לתמונה של התנאי הראשון לתמונה הדיפולטית הראשונה
        }
    }
    function Move() {
        if (document.getElementById("mD").src != '/pic/220px-Dinosaurmovieposter.jpg' && document.getElementById("mD").src != '/pic/10.-Lady-and-the-Tramp.jpg' && cnt2 == 0) {
            //תנאי שיבדוק שהתמונה ב היא דמבו md
            document.getElementById("mD").src = '/pic/220px-Dinosaurmovieposter.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("Z").src = '/pic/101dalmatians2lg.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("L").src = '/pic/The-Lion-King-3D-Official-Disney-Movie-Trailer-Coming-to-Theaters-October-7th-2011.jpg'; //משנה את מקור התמונה/שינוי התמונה
            document.getElementById("T").src = '/pic/oswald.jpg'; //משנה את מקור התמונה/שינוי התמונה
            cnt2++; //אם כן אז המשתנה מונה יעלה בעוד אחד  כדי שזה לא ישתנה שוב לאותה תמונה מבלי להפוך לתמונה אחרת
        }
        else {
            if (document.getElementById("mD").src != '/pic/43f34bc85ef2ba1a34c35f3f3ec98151.jpg' && document.getElementById("mD").src != '/pic/220px-Dinosaurmovieposter.jpg' && (cnt2 == 0 || cnt2 == -1)) {
                //תנאי שיבדוק שהתמונה ב היא דינוזאור md
                document.getElementById("mD").src = '/gifs/tumblr_inline_oybanyWRzo1uz3yzl_540.gif'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("Z").src = '/pic/Zootopia5669c94c462101.jpg'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("L").src = '/pic/the little mermaid.jpg'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("T").src = '/pic/treaure planet.jpeg'; //משנה את מקור התמונה/שינוי התמונה
                cnt2++; //אם כן אז המשתנה מונה יעלה בעוד אחד  כדי שזה לא ישתנה שוב לאותה תמונה מבלי להפוך לתמונה אחרת
            }
            else {
                document.getElementById("mD").src = '/pic/10.-Lady-and-the-Tramp.jpg'; //משנה את מקור התמונה/שינוי התמונה
                document.getElementById("Z").src = '/pic/5.-Finding-Nemo.jpg'; //משנה את מקור התמונה/שינוי התמונה
                    document.getElementById("L").src = '/pic/4.-Toy-Story-31.jpg'; //משנה את מקור התמונה/שינוי התמונה
                    document.getElementById("T").src = '/pic/1.-The-Lion-King1.jpg'; //משנה את מקור התמונה/שינוי התמונה
                    cnt2 = -1; //אם אחרת כלומר המשתנה מונה גדל אז התמונה צריכה להשתנות פעם הבאה לתנאי השני איפוס למספר 1- זה מאפשר לחזור לתמונה של התנאי הראשון לתמונה הדיפולטית הראשונה
            }
        }
    }
    function Dumbo() {
        document.getElementById("bigPicture").src = document.getElementById("mD").src;//התמונה הגדולה תהיה התמונה הקטנה הנוכחית בתמונה שבה לוחץ המשתמש
    }
    function Zootopia() {
        document.getElementById("bigPicture").src = document.getElementById("Z").src; //התמונה הגדולה תהיה התמונה הקטנה הנוכחית בתמונה שבה לוחץ המשתמש
    }
    function Little() {
        document.getElementById("bigPicture").src = document.getElementById("L").src; //התמונה הגדולה תהיה התמונה הקטנה הנוכחית בתמונה שבה לוחץ המשתמש
    }
    function TreaurePlanet() {
        document.getElementById("bigPicture").src = document.getElementById("T").src; //התמונה הגדולה תהיה התמונה הקטנה הנוכחית בתמונה שבה לוחץ המשתמש
    }



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<body>
    <div>

    </div>
<table align="center">
<tr style="width:1000px; height:100px">

<img id="bigPicture" src="/gifs/tumblr_inline_oybanyWRzo1uz3yzl_540.gif" style="width:1000px; height:500px":  />
</tr>
<tr>
<td><img src="/pic/Picture1 - Copy.png" onclick="return Back()" style="width:50px; height:50px;margin-left:500px" /></td>

<td><img src="/gifs/tumblr_inline_oybanyWRzo1uz3yzl_540.gif" id="mD" onclick="return Dumbo()" style="width:200px; height:200px " /></td>

<td style="width:10px"></td>

<td><img src="/pic/Zootopia5669c94c462101.jpg" id="Z"   onclick="return Zootopia()"  style="width:200px; height:200px;text-align:center" /></td>

<td style="width:10px"></td>

<td><img src="/pic/the little mermaid.jpg" id="L" onclick="return Little()" style="width:200px; height:200px;text-align:center"  /></td>

<td style="width:10px"></td>

<td><img src="/pic/treaure planet.jpeg" id="T" onclick="return TreaurePlanet()" style="width:200px; height:200px" /></td>

<td><img src="/pic/Picture1.png" onclick="return Move()" style="width:50px; height:50px"</td>

</tr>
<tr>

<td><img src="pic/1.-The-Lion-King1.jpg" style="width:200px; height:200px;visibility:hidden"/></td></tr>
</table>
</body>
</asp:Content>

