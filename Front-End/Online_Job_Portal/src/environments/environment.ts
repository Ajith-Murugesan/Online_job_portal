export const environment = {
    API_endpoints:{
        userAccount:"https://localhost:7119/UserAccount/GetAll",
        updateUserStatus:`https://localhost:7119/UserAccount/`,
        educationalDetails:"https://localhost:7119/EducationalDetails/Get/",
        saveeducationalDetails:"https://localhost:7119/EducationalDetails/CreateEducationalDetails",
        login:"https://localhost:7119/Auth/Login",
        resetPassword:"https://localhost:7119/UserAccount/ResetPassword",
        experienceDetails:"https://localhost:7119/ExperienceDetails/Get/",
        jobSeekerProfile:"https://localhost:7119/SeekerProfile/Get/",
        jobPosts:"https://localhost:7119/JobPost/Get/",
        deleteUser:"https://localhost:7119/UserAccount/DeleteAccount",
        applyJob:"https://localhost:7119/JobPostActivity/ApplyToJobPost",
        company:"https://localhost:7119/Company/GetAll",
        createJob:"https://localhost:7119/JobPost/CreateJobPost",
        location:"https://localhost:7119/JobLocation/GetAll",
        jobById:"https://localhost:7119/JobPost/GetById/",
        deleteJob:"https://localhost:7119/JobPost/DeleteJobPost/",
        appliedJobs:"https://localhost:7119/JobPostActivity/GetById/",
        jobApplications:"https://localhost:7119/UserAccount/GetJobApplications/",
        emailInvite:"https://localhost:7119/Mail/EmailInvite?toEmail=",
        createEmailInvite:"https://localhost:7119/SeekerProfile/CreateInterviewInvite",
        getUserEmail:"https://localhost:7119/UserAccount/Get/",
        getCompanyByEmployeer:"https://localhost:7119/Company/GetCompanyByEmployeer/",
        jobseekerProfileSave:"https://localhost:7119/SeekerProfile/CreateSeekerProfile",
        saveExperienceDetails:"https://localhost:7119/ExperienceDetails/CreateExperienceDetails",
        getInterviewInviteById:"https://localhost:7119/SeekerProfile/GetInterviewInviteById/"
    }
};
