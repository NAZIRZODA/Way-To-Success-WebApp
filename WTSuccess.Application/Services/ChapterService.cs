﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class ChapterService : BaseService<Chapter, ChapterResponseModel, ChapterRequestModel>, IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public ChapterService(IChapterRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _chapterRepository = repository;
            _mapper = mapper;
        }

        public override void Add(ChapterRequestModel request)
        {
            var parsedToCreate = request as CreateChapterRequestModel;
            if (parsedToCreate == null) throw new ArgumentNullException(nameof(Chapter));
            var mappedToChapter = _mapper.Map<CreateChapterRequestModel, Chapter>(parsedToCreate);
            _chapterRepository.Add(mappedToChapter);
            _chapterRepository.SaveChanges();
        }

        public override ChapterResponseModel Get(ulong id)
        {
            var dbChapter = _chapterRepository.FindById(id);
            if (dbChapter == null) throw new ArgumentNullException(nameof(Chapter));
            var mappedToResponse = _mapper.Map<Chapter, ChapterResponseModel>(dbChapter);
            return mappedToResponse;
        }

        public override IEnumerable<ChapterResponseModel> GetAll(int pageList, int pageNumber)
        {
            var dbChapter = _chapterRepository.GetAll(pageList, pageNumber);
            var mappedToRespones = _mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterResponseModel>>(dbChapter);
            return mappedToRespones;
        }

        public override ChapterResponseModel Update(ulong id, ChapterRequestModel request)
        {
            var dbChapter = _chapterRepository.FindById(id);
            if (dbChapter == null) throw new ArgumentNullException(nameof(Chapter));
            var chapterRequestToUpdate = request as UpdateChapterRequestModel;
            dbChapter.Topics = chapterRequestToUpdate.Topics;
            dbChapter.Course = chapterRequestToUpdate.Course;
            dbChapter.CourseId = chapterRequestToUpdate.CourseId;
            _chapterRepository.Update(dbChapter);
            _chapterRepository.SaveChanges();
            return _mapper.Map<UpdateChapterRequestModel, ChapterResponseModel>(chapterRequestToUpdate);
        }

        public override bool Delete(ulong id)
        {
            var dbChapter = _chapterRepository.FindById(id);
            if (dbChapter == null) throw new ArgumentNullException(nameof(Chapter));
            _chapterRepository.Delete(dbChapter);
            _chapterRepository.SaveChanges();
            return true;
        }
    }
}
