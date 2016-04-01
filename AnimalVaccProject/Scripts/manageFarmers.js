
//clean both dropdownlist of niyabat and villages
$("#AddNiyabats option").remove();
$("#AddVillages option").remove();

//add new Farmer ------------------------------------------------------------------------------------------------------------------------------
function addNewFarmer(UrlAddNew) {
    var txtAddName = $("#txtAddName").val();
    var ID2 = $("#ID2").val();

    // in the case of adding new farmer we are going to use the following variables
    var frName = $(".AddName").val();
    var civilId = $(".AddcivilId").val();
    var WID = $("#AddWillayts").val();
    var NID = $("#AddNiyabats").val();
    var VID = $("#AddVillages").val();
    var Tel = $(".AddTel").val();
    var Job = $(".AddJob").val();
    //getting the url
    var UrlGetAll = $("#UrlGetAll").val();
    // var UrlAddNew = $("#UrlAddNew").val();

    if (frName == null || frName == '' || civilId == null || civilId == '') {
        $("#txtNameError").text("الرجاء كتابة البيانات").css("color", "red");
        return false;
    } else {
        var url = UrlAddNew + '?frName=' + frName + '&civilId=' + civilId + '&WID=' + WID + '&NID=' + NID + '&VID=' + VID + '&Tel=' + Tel + '&Job=' + Job;
    }
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            //$(".status").addClass("statusstyle");
            //$("#statusMsg").html(data.message);
            //$("#FarmerListContainer").load(UrlGetAll);
        },
        error: function (error) {
            //to do:
        }
    });

    //clear values and close the dialog box
    $("#txtName").val("");
    $(".AddName").val("");
    $(".AddcivilId").val("");
    $(".AddTel").val("");
    $(".AddJob").val();
    $("#txtNameError").text("");
    $("#txtName").removeClass('inputfocus');
    $("#divAddFarmers").dialog("close")
}

$(document).on("click", 'a.lnkAddNew', function () {
    var UrlAddNew = $(this).data('controller-action');//this will contain the name of the controller and the action
    var type = $(this).data("type");
    $(".status").removeClass("statusstyle");
    $("#statusMsg").html("");
    $("#divAddFarmers").dialog({
        modal: true,
        draggable: false,
        resizable: false,
        position: { my: "center", at: "center", of: window },
        show: 'blind',
        hide: 'blind',
        width: 400,
        dialogClass: 'ui-dialog-osx',
        buttons: [
    {
        text: "إضافة ",
        "class": 'btn btn-default',
        click: function () {
            addNewFarmer(UrlAddNew, type);
        }
    },
    {
        text: "إلغاء",
        "class": 'btn btn-default',
        click: function () {
            $(this).dialog("close").addClass('btn btn-default');
        }
    }
        ],
        close: function () {
            // Close code here (incidentally, same as Cancel code)
        }
    });
});

//edit farmer data ----------------------------------------------------------------------------------------------------------------------------
function editFarmer(id, name, cid, wlt, nbt, vlg, tel, job, UrlUpdate) {
    var UrlGetAll = $("#UrlGetAll").val(); //display all the data after updating
    var url = UrlUpdate + '?' + 'id=' + id + '&name=' + name + '&cid=' + cid + '&wlt=' + wlt + '&nbt=' + nbt + '&vlg=' + vlg + '&tel=' + tel + '&job=' + job;
    console.log(url);
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            $(".status").addClass("statusstyle");
            $("#statusMsg").html(data.message);
            $("#FarmerListContainer").load(UrlGetAll);
            //$("#divUserListContainer").load("@(Url.Action("getVList", "agrVillages"))");
        },
        error: function (error) {
            //to do:
        }
    });
}

$(document).on("click", "a.lnkEdit", function (e) {
    e.preventDefault();
    $(".alert-success").empty();
    var row = $(this).closest('tr');
    var UrlUpdate = $(this).data('controller-action');
    
    //var getDataType = $(this).data('type');
    $("#hidID").val(row.find("td:eq(0)").html().trim());

    var id = row.find("td:eq(0)").html().trim();

    //finding the selected willayat
    var wlt = row.find("td:eq(5)").html().trim();
    //$("#ddlEditWillayts option").filter(function () {
    //    return this.value == wlt;
    //}).attr('selected', true);

    var $select = $('#ddlEditWillayts');
    $select.change(function () {
        $select.val(wlt);
    }).change();

    //finding the selected niyabat
    var nbt = row.find("td:eq(7)").html().trim();
    //$("#ddlEditNiyabats option").filter(function () {
    //    return this.value == nbt;
    //}).attr('selected', true);

    var $select = $('#ddlEditNiyabats');
    $select.change(function () {
        $select.val(nbt);
    }).change();


    //finding the selected village
    var vlg = row.find("td:eq(9)").html().trim();
    //$("#ddlEditVillages option").filter(function () {
    //    return this.value == vlg;
    //}).attr('selected', true);

    var $select = $('#ddlEditVillages');
    $select.change(function () {
        $select.val(vlg);
    }).change();
    var getName= row.find("td:eq(2)").html().trim();
    var getCivilId= row.find("td:eq(3)").html().trim();
    var getTel = row.find("td:eq(10)").html().trim();
    var getJob = row.find("td:eq(11)").html().trim()
    $("#txtName").val(getName); 
    $("#civilId").val(getCivilId);
    $(".Tel").val(getTel);
    $(".Job").val (getJob);

    //open the dialog
    $("#divEditFarmers").dialog({
        modal: true,
        draggable: false,
        resizable: false,
        position: { my: "center", at: "center", of: window },
        show: 'blind',
        hide: 'blind',
        width: 400,
        dialogClass: 'ui-dialog-osx',
        buttons: {
            "إضافة التعديلات": function () {

                var name = $("#txtName").val(); //display the farmer name on dialog box, text field
                var cid = $("#civilId").val();
                var wlt = $("#ddlEditWillayts").find(":selected").val();
                var nbt = $("#ddlEditNiyabats").find(":selected").val();
                var vlg = $("#ddlEditVillages").find(":selected").val();
                var tel = $(".Tel").val();
                var job = $(".Job").val();
                editFarmer(id, name, cid, wlt, nbt, vlg, tel, job, UrlUpdate);
                $(this).dialog("destroy");
            },
            "إلغاء التعديلات": function () {
                //$("#ddlEditWillayts option[value='" + wlt + "']").removeAttr("selected");
                //$("#ddlEditNiyabats option[value='" + nbt + "']").removeAttr("selected");
                //$("#ddlEditVillages option[value='" + vlg + "']").removeAttr("selected");
                $(this).dialog("destroy");
            }
        }
    });
    //return false;
});

//when dropdownlist willayats changes----------------------------------------------------------------------------------------------------------
$(document).on('change', "#AddWillayts", function () {
    var WID = $(this).val();
    $("#AddNiyabats option").remove();
    url = "/Farmers/getNiyabatlst" + "?WID=" + WID;
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            var seloption = "";
            $(".status").addClass("statusstyle");
            $("#statusMsg").html(data.message);
            $("#AddNiyabats").append($("<option></option>").text("الرجاء إختيار النيابة").val("0"));
            $.each(data, function (i, nybt) {

                $("#AddNiyabats").append($("<option></option>")
                    .text(nybt.NName)
                    .val(nybt.NID)
                    );
            });

        },
        error: function (error) {
            //to do:
        }
    });
});

//when dropdownlist Niyabats changes-----------------------------------------------------------------------------------------------------------
$(document).on('change', "#AddNiyabats", function () {
    var NID = $(this).val();
    $("#AddVillages option").remove();
    url = "/Farmers/getVillageslst" + "?NID=" + NID;
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            $("#AddVillages").append($("<option></option>").text("الرجاء إختيار القرية").val("0"));
            var seloption = "";
            $(".status").addClass("statusstyle");
            $("#statusMsg").html(data.message);
            $.each(data, function (i, vybt) {
                $("#AddVillages").append($("<option></option>")
                    .text(vybt.VName)
                    .val(vybt.VID)
                    );
            });

        },
        error: function (error) {
            //to do:
        }
    });
});

// Delete data --------------------------------------------------------------------------------------------------------------------------------
function Delete(ID, UrlDelete) {
    var UrlGetAll = $("#UrlGetAll").val();// this is a hiddent file which contains the url to show all the data
    var url = UrlDelete + '?' + "ID=" + ID;
    //var url = '@Url.Action("DeleteConfirmed", "agrVillages")' + '?' + "ID=" + ID;
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            $(".status").addClass("statusstyle");
            $("#statusMsg").html(data.message);
            $("#FarmerListContainer").load(UrlGetAll);
            //$("#divUserListContainer").load("@(Url.Action("getVList", "agrVillages"))");
        },
        error: function (error) { }
    });
}

//the reason we used $(document).on("click",'a.lnkDelete', function () {}); 
//insted of $(a.lnkDelete).on("click", function () {}); because the a.lnkDelete will not fire after it loaded using ajax, the action assoicated with button will be lost after ajax is loading the new elements
$(document).on("click", 'a.lnkDelete', function (e) {
    e.preventDefault();
    var UrlDelete = $(this).data('controller-action');
    var row = $(this).closest('tr');
    var ID = row.find("td:eq(0)").html().trim();
    var txtName = row.find("td:eq(2)").html().trim();
    var answer = confirm("هل تريد البيانات -- " + txtName + " -- .إستمر?");
    if (answer)
        Delete(ID, UrlDelete);
    return false;
});

//search for Farmer---------------------------------------------------------------------------------------------------------------------------
$(document).on('click', '#btnSearch', function (e) {
    e.preventDefault();
    var UrlFindFarmer = $(this).data('controller-action'); // the url to the action inside agrVillage controll which will be used for searching
    var txtFarmer = $("#txtSearchFarmer").val();
    if (txtFarmer == null || txtFarmer == '') {
        $(".status").addClass("statusstyle");
        $("#statusMsg").html("الرجاء إستكمال بيانات البحث");
        $("#txtSearchFarmer").focus().addClass('inputfocus');

        return false;
    }
    else {
        //clear values and close the dialog box
        $("#txtSearchFarmer").val("");
        $("#txtSearchFarmer").removeClass('inputfocus');
        $(".status").removeClass("statusstyle");
        $("#statusMsg").html("");

        findFarmer(txtFarmer, UrlFindFarmer);
    }
});

function findFarmer(txtFarmer, UrlFindFarmer) {
    var UrlGetAll = $("#UrlGetAll").val(); //display all the data after updating
    var url = UrlFindFarmer + '?' + "flName=" + txtFarmer;
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            $(".status").addClass("statusstyle");
            $("#statusMsg").html(data.message);
            var output = $("#FarmerListContainer");
            output.empty();
            var content="<table id=" + "wlist" + " class=" + "table" + ">" +
                    "<tr class=" + "hdr" + ">" +
                    "<th style=" + "display:none;" + ">م</th>" +
                    "<th></th>" +
                    "<th>إسم المربي</th>"+
                    "<th>الرقم المدني</th>"+       
                    "<th>إسم الولاية</th>"+
                    "<th>إسم النيابة</th>"+ 
                    "<th>إسم القرية</th>" +
                    "<th>الهاتف</th>"+
                    "<th>الوظيفة</th>"+
                    "<th></th>"+
                    "</tr>"
            for (var i = 0; i < data.agrFarlst.length ; i++) {
                    var Farmer = data.agrFarlst[i];
                    content +=
                    "<tr>" +
                    "<td style=" + "display:none;" + ">" + Farmer.FarmerId + "</td>" +
                    "<th><img src="+"/Content/Images/Assets/001_55.png"+" />"+
                    "<td>" + Farmer.Name + "</td>" +
                    "<td>" + Farmer.civilId + "</td>" +
                    "<td>" + Farmer.WName + "</td>" +
                    "<td style=" + "display:none;" + ">" + Farmer.WID + "</td>" +
                    "<td> " + Farmer.NName + "</td>" +
                    "<td style=" + "display:none;" + ">" + Farmer.NID + "</td>" +
                    "<td>" + Farmer.VName + "</td> " +
                    "<td style=" + "display:none;" + ">" + Farmer.VID + "</td>" +
                    "<td>" + Farmer.Tel + "</td>" +
                    "<td>" + Farmer.Job + "</td>" +
                    "<td class=" + "rf" + ">" +
                    "<a data-controller-action=" + "/Farmers/UpdateFarmer" + " class=" + "lnkEdit" + "  href=" + "#" + ">تعديل</a>|" +
                    "<a data-controller-action=" + "/Farmers/DeleteFarmer" + " class=" + "lnkDelete" + " href=" + "#" + ">حذف</a></td></tr>";
                    "</tr>"

                  

                    //"<a href=" + "javascript:void(0)" + " class=" + "lnkEdit" + " data-controller-action=" + upldateLin + ">تعديل</a>|" +
                    //"<a href=" + "javascript:void(0)" + " class=" + "lnkDelete" + ">حذف</a></td></tr></table>");
            }
            content += "</table>";


            output.append(content);
        },
        error: function (error) {
            //to do:
        }
    });
}

//show all the data ------------------------------------------------------------------------------------------------
$(document).on('click', 'a.lnkShowAll', function () {
    var UrlShowAll = $(this).data('controller-action');
    var url = UrlShowAll;
    $.ajax({
        type: "POST",
        url: url,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        cache: false,
        success: function (data) {
            $("#FarmerListContainer").load(UrlShowAll);
            //$("#divUserListContainer").load("@(Url.Action("getVList", "agrVillages"))");
        },
        error: function (error) {
            //to do:
        }
    });
});

