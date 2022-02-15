﻿// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

using System;

using System.Threading.Tasks;

using Grpc.Core;

using UbudKusCoin.Services;

namespace UbudKusCoin.Grpc
{

    public class BlockServiceImpl : BlockService.BlockServiceBase
    {
        public override Task<AddBlockStatus> Add(Block block, ServerCallContext context)
        {
            Console.WriteLine("== BlockServiceImpl, Add :", block);
            var addStatus = ServicePool.DbService.blockDb.Add(block);
            return Task.FromResult(addStatus);
        }
        public override Task<Block> GetFirst(Block request, ServerCallContext context)
        {
            var block = ServicePool.DbService.blockDb.GetFirst();
            return Task.FromResult(block);
        }
        public override Task<Block> GetLast(Block request, ServerCallContext context)
        {
            var block = ServicePool.DbService.blockDb.GetLast();
            return Task.FromResult(block);
        }
        public override Task<Block> GetByHash(Block request, ServerCallContext context)
        {
            var block = ServicePool.DbService.blockDb.GetByHash(request.Hash);
            return Task.FromResult(block);
        }
        public override Task<Block> GetByHeight(Block request, ServerCallContext context)
        {
            var block = ServicePool.DbService.blockDb.GetByHeight(request.Height);
            return Task.FromResult(block);
        }
        public override Task<BlockList> GetRange(BlockParams request, ServerCallContext context)
        {
            var blocks = ServicePool.DbService.blockDb.GetRange(request.PageNumber, request.ResultPerPage);
            var list = new BlockList();
            list.Blocks.AddRange(blocks);
            return Task.FromResult(list);
        }

        public override Task<BlockList> GetRemains(StartingParam request, ServerCallContext context)
        {
            var blocks = ServicePool.DbService.blockDb.GetRemains(request.Height);
            var list = new BlockList();
            list.Blocks.AddRange(blocks);
            return Task.FromResult(list);
        }



    }
}
