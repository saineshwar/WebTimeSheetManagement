function ValidateFilename(value)
{
    var file = getNameFromPath($(value).val());
    var objRE = new RegExp(/^[a-zA-Z0-9]+$/);
    var extension = file.substr(0, file.lastIndexOf('.'));
    var strName = objRE.exec(extension);

    if (strName == null) {
        var str = value.name;

        var data = "val_file";
        var msg = "Uploaded filename is invalid " + '*' + extension + '*' + "";
        $("#" + data).text(msg);
        $("#" + value.name).val('');
        return false;
    }
    else {
        $("#" + data).text("");
        return true;
    }

}

function ValidateFileSize(fileid) {
    try {
        var fileSize = 0;
        fileSize = $(fileid)[0].files[0].size //size in kb
        fileSize = parseFloat(fileSize / 1024).toFixed(2);
        return fileSize;
    }
    catch (e) {
        alert("Error is :" + e);
    }
}

function getNameFromPath(strFilepath) {
    var objRE = new RegExp(/([^\/\\]+)$/);
    var strName = objRE.exec(strFilepath);

    if (strName == null) {
        return null;
    }
    else {
        return strName[0];
    }
}

function ValidateFile(value) {

    var file = getNameFromPath($(value).val());
    var extension = file.substr((file.lastIndexOf('.') + 1));
    if (file != null) {

        switch (extension) {
            case 'zip':
                flag = true;
                break;
            case 'rar':
                flag = true;
                break;
            default:
                flag = false;
        }
    }

    if (flag == false) {

        var str = value.name;
        var data = "val_file";
        $("#" + data).text("You can upload only .zip extension file");
        $("#" + value.name).val('');
        return false;
    }
    else {

        var Validfilename = ValidateFilename(value);

        if (Validfilename == true) {

            var size = ValidateFileSize(value);
            var str = value.name;
            var data = "val_file";
            if (extension == "jpg" || extension == "jpeg")
            {
                if (size > 100) {
                    $("#" + data).text("The size of the jpg documents Must be less than 100 KB.");
                    $("#" + value.name).val('');
                } else {
                    $("#" + data).text("");
                }
            }
            else if (extension == "zip")
            {
                if (size > 500) {
                    $("#" + data).text("The size of the zip documents Must be less than 500 KB.");
                    $("#" + value.name).val('');
                } else {
                    $("#" + data).text("");
                }
            }
            else {
                $("#" + data).text("");
            }

        }
    }

}

function ValidateFilenameSingle(value) {
    var file = getNameFromPath($(value).val());
    var objRE = new RegExp(/^[a-zA-Z0-9]+$/);
    var extension = file.substr(0, file.lastIndexOf('.'));
    var strName = objRE.exec(extension);

    if (strName == null) {
        var str = value.name;

        var data = "val_fileSingle";
        var msg = "Uploaded filename is invalid " + '*' + extension + '*' + "";
        $("#" + data).text(msg);
        $("#" + value.name).val('');
        return false;
    }
    else {
        $("#" + data).text("");
        return true;
    }

}

function ValidateFileSizeSingle(fileid) {
    try {
        var fileSize = 0;
        fileSize = $(fileid)[0].files[0].size //size in kb
        fileSize = parseFloat(fileSize / 1024).toFixed(2);
        return fileSize;
    }
    catch (e) {
        alert("Error is :" + e);
    }
}

function ValidateImagesOnly(value) {

    var file = getNameFromPath($(value).val());
    var extension = file.substr((file.lastIndexOf('.') + 1));
    if (file != null) {

        switch (extension) {
            case 'png':
                flag = true;
                break;
            case 'jpg':
                flag = true;
                break;
            case 'jpeg':
                flag = true;
                break;
            default:
                flag = false;
        }
    }

    if (flag == false) {

        var str = value.name;
        var data = "val_fileSingle";
        $("#" + data).text("You can upload .png .jpg extension file");
        $("#" + value.name).val('');
        return false;
    }
    else {

        var Validfilename = ValidateFilenameSingle(value);

        if (Validfilename == true) {

            var size = ValidateFileSizeSingle(value);
            var str = value.name;
            var data = "val_fileSingle";
            if (extension == "jpg" || extension == "jpeg") {
                if (size > 100) {
                    $("#" + data).text("The size of the jpg documents Must be less than 100 KB.");
                    $("#" + value.name).val('');
                } else {
                    $("#" + data).text("");
                }
            }
            else if (extension == "zip") {
                if (size > 500) {
                    $("#" + data).text("The size of the zip documents Must be less than 500 KB.");
                    $("#" + value.name).val('');
                } else {
                    $("#" + data).text("");
                }
            }
            else {
                $("#" + data).text("");
            }

        }
    }

}