﻿using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Data_Access_Layer.Repositories
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly IConfiguration _config;

        public JobPostRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<ICollection<JobpostDetails>> GetJobPostById(int jobPostId)
        {
            List<JobpostDetails> jobPost = new List<JobpostDetails>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("GetJobPostDetailsById", con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId); 

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            jobPost.Add(new JobpostDetails
                            {
                                JobPostId = reader.GetInt32(0),
                                UserAccountId = reader.GetInt32(1),
                                CompanyName = reader.GetString(2),
                                JobTypeName = reader.GetString(3),
                                JobDescription = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                JobTitle = reader.GetString(5),
                                CreatedDate = reader.GetDateTime(6),
                                Address = reader.GetString(7),
                                City = reader.GetString(8),
                                State = reader.GetString(9),
                                Pincode = reader.GetInt32(10),
                                IsActive = reader.GetString(11)
                            });
                        }
                    }
                }
            }

            return jobPost;
        }

        public async Task<ICollection<JobpostDetails>> GetJobPost()
        {
            List<JobpostDetails> jobPosts = new List<JobpostDetails>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("GetJobPostDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            jobPosts.Add(new JobpostDetails
                            {
                                JobPostId = reader.GetInt32(0),
                                UserAccountId = reader.GetInt32(1),
                                CompanyName = reader.GetString(2),
                                JobTypeName = reader.GetString(3),
                                JobDescription = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                JobTitle= reader.GetString(5),
                                CreatedDate = reader.GetDateTime(6),
                                Address = reader.GetString(7),
                                City = reader.GetString(8),
                                State = reader.GetString(9),
                                Pincode = reader.GetInt32(10),
                                IsActive = reader.GetString(11)
                            });
                        }
                    }
                }
            }

            return jobPosts;
        }


        public async Task<ICollection<JobPost>> GetAllJobPosts()
        {
            List<JobPost> jobPosts = new List<JobPost>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT job_post_id, user_account_id, company_id, job_type_id, job_description, created_date, location_id, is_active,job_title FROM job_post", con))
                
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        jobPosts.Add(new JobPost
                        {
                            JobPostId = reader.GetInt32(0),
                            UserAccountId = reader.GetInt32(1),
                            CompanyId = reader.GetInt32(2),
                            JobTypeId = reader.GetInt32(3),
                            JobDescription = reader.IsDBNull(1) ? "" : reader.GetString(4),
                            CreatedDate = reader.IsDBNull(1) ? new DateTime() : reader.GetDateTime(5),
                            LocationId = reader.GetInt32(6),
                            IsActive = reader.IsDBNull(1) ? "" :reader.GetString(7),
                            JobTitle = reader.IsDBNull(1) ? "" : reader.GetString(8)
                        });
                    }
                }
            }

            return jobPosts;
        }

        public async Task<JobPost> CreateJobPost(JobPost jobPost)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO job_post (user_account_id, company_id, job_type_id, job_description, location_id,job_title) " +
                                     "VALUES (@UserAccountId, @CompanyId, @JobTypeId, @JobDescription, @LocationId,@title);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", jobPost.UserAccountId);
                    cmd.Parameters.AddWithValue("@CompanyId", jobPost.CompanyId);
                    cmd.Parameters.AddWithValue("@JobTypeId", jobPost.JobTypeId);
                    cmd.Parameters.AddWithValue("@JobDescription", jobPost.JobDescription);
                    cmd.Parameters.AddWithValue("@LocationId", jobPost.LocationId);
                    cmd.Parameters.AddWithValue("@title", jobPost.JobTitle);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return jobPost;
        }

        public async Task<JobPost> UpdateJobPost(JobPost updatedJobPost)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE job_post SET user_account_id = @UserAccountId, company_id = @CompanyId, job_type_id = @JobTypeId, " +
                                     "job_description = @JobDescription, created_date = @CreatedDate, location_id = @LocationId, is_active = @IsActive,job_title=@title " +
                                     "WHERE job_post_id = @JobPostId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobPostId", updatedJobPost.JobPostId);
                    cmd.Parameters.AddWithValue("@UserAccountId", updatedJobPost.UserAccountId);
                    cmd.Parameters.AddWithValue("@CompanyId", updatedJobPost.CompanyId);
                    cmd.Parameters.AddWithValue("@JobTypeId", updatedJobPost.JobTypeId);
                    cmd.Parameters.AddWithValue("@JobDescription", updatedJobPost.JobDescription);
                    cmd.Parameters.AddWithValue("@CreatedDate", updatedJobPost.CreatedDate);
                    cmd.Parameters.AddWithValue("@LocationId", updatedJobPost.LocationId);
                    cmd.Parameters.AddWithValue("@IsActive", updatedJobPost.IsActive);
                    cmd.Parameters.AddWithValue("@title", updatedJobPost.JobTitle);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedJobPost;
        }

        public async Task<UpdateUserStatusResponse> DeleteJobPost(int jobPostId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM job_post WHERE job_post_id = @JobPostId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            var response = new UpdateUserStatusResponse
            {
                Message = "User deleted successfully"
            };

            return response;
        }
    }
}
