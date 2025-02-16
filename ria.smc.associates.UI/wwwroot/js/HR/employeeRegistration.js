$(function () {
    'use strict';

    //$('#PROFILEPICTURE').dropify();

    $("#employeeRegistrationForm").steps({
        headerTag: 'h2',
        bodyTag: 'section',
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
            $("#employeeRegistrationForm").validate().settings.ignore = ":disabled,:hidden";
            return $("#employeeRegistrationForm").valid();
        },
        onFinishing: function (event, currentIndex) {
            $("#employeeRegistrationForm").validate().settings.ignore = ":disabled,:hidden";
            return $("#employeeRegistrationForm").valid();
        },
        onFinished: function (event, currentIndex) {
            $("#employeeRegistrationForm").submit();
        }
    });

    if ($('#datePicker_DATEOFBIRTH').length) {
        var date = new Date();
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $('#datePicker_DATEOFBIRTH').datepicker({
            format: "mm/dd/yyyy",
            todayHighlight: true,
            autoclose: true
        });
        $('#datePicker_DATEOFBIRTH').datepicker();
    }
    if ($('#datePicker_DATEOFJOINING').length) {
        var date = new Date();
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $('#datePicker_DATEOFJOINING').datepicker({
            format: "mm/dd/yyyy",
            todayHighlight: true,
            autoclose: true
        });
        $('#datePicker_DATEOFJOINING').datepicker();
    }

    $("#CNIC, #MOBILENO, #EMERGENCYCONTACTNUMBER").inputmask();

    $.validator.setDefaults({
        submitHandler: function (form) {
            if ($(form).valid())
                form.submit();
            return false;
            //$("#employeeRegistrationForm").submit();
        }
    });

    $("#employeeRegistrationForm").validate({
        rules: {
            EMPLOYEENAME: { required: true, maxlength: 50 },
            FATHERNAME: { required: true, maxlength: 50 },
            CNIC: { required: true },
            DATEOFBIRTH: { required: true },
            GENDER: { required: true },
            MARITALSTATUS: { required: true },
            BLOODGROUP: { required: true },
            NATIONALITY: { required: true },
            MOBILENO: { required: true },
            EMAIL: { required: false, email: true, maxlength: 50 },
            PERMANENETADDRESS: { required: true, maxlength: 3000 },
            CURRENTADDRESS: { required: true, maxlength: 3000 },
            EMERGENCYCONTACTNAME: { required: true, maxlength: 50 },
            EMERGENCYCONTACTRELATION: { required: true },
            EMERGENCYCONTACTNUMBER: { required: true },
            DATEOFJOINING: { required: true },
            EMPLOYEETYPE: { required: true },
            DESIGNATION: { required: true, maxlength: 50 },
            DEPARTMENT: { required: true, maxlength: 50 },
            EMPLOYEESTATUS: { required: true },
            HIGHESTQUALIFICATION: { required: true, maxlength: 50 },
            SPECILIZATION: { required: false, maxlength: 50 },
            CERTIFICATION: { required: false, maxlength: 50 },
            EXPERIENCE: { required: false, maxlength: 50 },
            BASICSALARY: { required: false, maxlength: 9 },
            GROSSSALARY: { required: false, maxlength: 9 },
            BANKNAME: { required: true, maxlength: 50 },
            BRANCH: { required: true, maxlength: 50 },
            ACCOUNTNUMBER: { required: true, maxlength: 200 }
        },
        messages: {
            EMPLOYEENAME: { required: "The Employee Name is required.", maxlength: "The Employee Name must be less than 50 characters long." },
            FATHERNAME: { required: "The Father Name is required.", maxlength: "The Father Name must be less than 50 characters long." },
            CNIC: { required: "The CNIC is required." },
            DATEOFBIRTH: { required: "The Date of Birth is required." },
            GENDER: { required: "The Gender is required." },
            MARITALSTATUS: { required: "The Marital Status is required." },
            BLOODGROUP: { required: "The Blood Group is required." },
            NATIONALITY: { required: "The Nationality is required." },
            MOBILENO: { required: "The Mobile Number is required." },
            EMAIL: { required: false, email: 'The Email is invalid, enter valid email.', maxlength: "The Email must be less than 50 characters long." },
            PERMANENETADDRESS: { required: "The Permanenet Address is required.", maxlength: "The Permanenet Address must be less than 3000 characters long." },
            CURRENTADDRESS: { required: "The Current Address is required.", maxlength: "The Current Address must be less than 3000 characters long." },
            EMERGENCYCONTACTNAME: { required: "The Emergency Contact Name is required.", maxlength: "The Emergency Contact Name must be less than 50 characters long." },
            EMERGENCYCONTACTRELATION: { required: "The Emergency Contact Relation is required." },
            EMERGENCYCONTACTNUMBER: { required: "The Emergency Contact Number is required." },
            DATEOFJOINING: { required: "The Date of Joining is required." },
            EMPLOYEETYPE: { required: "The Employee Type is required." },
            DESIGNATION: { required: "The Department is required.", maxlength: "The Department must be less than 50 characters long." },
            DEPARTMENT: { required: "The Designation is required.", maxlength: "The Designation must be less than 50 characters long." },
            EMPLOYEESTATUS: { required: "The Employee Status is required." },
            HIGHESTQUALIFICATION: { required: "The Highest Qualification is required.", maxlength: "The Highest Qualification must be less than 50, characters long." },
            SPECILIZATION: { required: false, maxlength: "The Specilization must be less than 50, characters long." },
            CERTIFICATION: { required: false, maxlength: "The Certification must be less than 50, characters long." },
            EXPERIENCE: { required: false, maxlength: "The Experience must be less than 50, characters long." },
            BASICSALARY: { required: false, maxlength: "The Basic Salary must be less than 50, characters long." },
            GROSSSALARY: { required: false, maxlength: "The Gross Salary must be less than 50, characters long." },
            BANKNAME: { required: "The Bank Name is required.", maxlength: "The Bank Name must be less than 50, characters long." },
            BRANCH: { required: "The Branch is required.", maxlength: "The Branch must be less than 50, characters long." },
            ACCOUNTNUMBER: { required: "The Account Number is required.", maxlength: "The Account Number must be less than 200, characters long." }
        },
        errorPlacement: function (label, element) {
            label.addClass('mt-2 text-danger');
            label.insertAfter(element);
        },
        highlight: function (element, errorClass) {
            $(element).parent().addClass('has-danger')
            $(element).addClass('form-control-danger')
        },
        success: function (element, succesClass) {
            $(element).parent().removeClass('has-danger')
        }
    });
});