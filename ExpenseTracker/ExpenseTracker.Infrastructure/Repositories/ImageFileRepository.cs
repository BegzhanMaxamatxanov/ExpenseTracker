﻿using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Interfaces;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

internal class ImageFileRepository : RepositoryBase<ImageFile>, IImageFileRepository
{
    public ImageFileRepository(ExpenseTrackerDbContext context)
        : base(context)
    {
    }

    public override List<ImageFile> GetAll(Guid userId)
    {
        var images = _context.ImageFiles
            .AsNoTracking()
            .Where(x => x.Transfer.Category.UserId == userId)
            .ToList();

        return images;
    }

    public List<ImageFile> GetByTransferId(int transferId)
    {
        var images = _context.ImageFiles
            .AsNoTracking()
            .Where(x => x.TransferId == transferId)
            .ToList();

        return images;
    }
}
