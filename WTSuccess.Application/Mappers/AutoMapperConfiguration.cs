using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.CourseRequests;
using WTSuccess.Application.Requests.GamePlayerRequest;
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Requests.GameRequests;
using WTSuccess.Application.Requests.LevelRequests;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Application.Requests.StudentExamRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.CourseRespnses;
using WTSuccess.Application.Responses.GamePlayerResponses;
using WTSuccess.Application.Responses.GameQuestionResponses;
using WTSuccess.Application.Responses.GameResponses;
using WTSuccess.Application.Responses.LevelResponses;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Application.Responses.StudentAnswerResponses;
using WTSuccess.Application.Responses.StudentExamRespones;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Domain.Models;
using WTSuccess.Domain.Models.CourseScene;
using WTSuccess.Domain.Models.ExamScene;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<StudentRequestModel, Student>();
            CreateMap<Student, StudentResponseModel>();
            CreateMap<UpdateStudentRequestModel, Student>();

            CreateMap<CourseRequestModel, Course>();
            CreateMap<Course, CourseResponseModel>();
            CreateMap<UpdateCourseRequestModel, Course>();

            CreateMap<ChapterRequestModel, Chapter>();
            CreateMap<Chapter, ChapterResponseModel>();
            CreateMap<UpdateChapterRequestModel, Chapter>();

            CreateMap<TopicRequestModel, Topic>();
            CreateMap<Topic, TopicResponseModel>();
            CreateMap<UpdateTopicRequestModel, Topic>();

            CreateMap<CreateQuestionRequestModel, Question>();
            CreateMap<Question, QuestionResponseModel>();
            CreateMap<UpdateQuestionRequestModel, Question>();

            CreateMap<CreateAnswerRequestModel, Answer>();
            CreateMap<Answer, AnswerResponseModel>();

            CreateMap<CreateStudentExamRequestModel, StudentExam>();
            CreateMap<StudentExam, StudentExamResponseModel>();
            CreateMap<UpdateStudentExamRequestModel, StudentExam>();

            CreateMap<CreateStudentAnswerRequestModel, StudentAnswer>();
            CreateMap<StudentAnswer, StudentAnswerResponseModel>();
            CreateMap<UpdateStudentAnswerRequestModel, StudentAnswer>();

            CreateMap<CreateGameQuestionRequestModel, GameQuestion>();
            CreateMap<GameQuestion, GameQuestionResponseModel>();
            CreateMap<UpdateGameQuestionRequestModel, GameQuestion>();

            CreateMap<CreateGameQuestionAnswerRequestModel, GameQuestionAnswer>();
            CreateMap<GameQuestionAnswer, GameQuestionAnswerResponseModel>();

            CreateMap<CreateGamePlayerRequestModel, GamePlayer>();
            CreateMap<GamePlayer, GamePlayerResponseModel>();
            CreateMap<UpdateGamePlayerRequestModel, GamePlayer>();

            CreateMap<CreateGameRequestModel, Game>();
            CreateMap<Game, GameResponseModel>();
            CreateMap<UpdateGameRequestModel, Game>();

            CreateMap<CreateLevelRequestModel, Level>();
            CreateMap<Level, LevelResponseModel>();
            CreateMap<UpdateLevelRequestModel, Level>();
        }
    }
}
