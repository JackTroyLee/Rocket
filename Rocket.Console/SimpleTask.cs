﻿using System;
using Rocket.API;
using Rocket.API.Scheduler;

namespace Rocket.ConsoleImplementation
{
    public class SimpleTask : ITask
    {
        private readonly ITaskScheduler scheduler;

        internal SimpleTask(ITaskScheduler scheduler, ILifecycleObject owner, Action action,
                            ExecutionTargetContext executionTarget)
        {
            Owner = owner;
            Action = action;
            ExecutionTarget = executionTarget;
            this.scheduler = scheduler;
        }

        public ILifecycleObject Owner { get; }
        public Action Action { get; }
        public bool IsCancelled { get; internal set; }
        public ExecutionTargetContext ExecutionTarget { get; }
        public bool IsFinished => !scheduler.Tasks.Contains(this);

        public void Cancel()
        {
            scheduler.CancelTask(this);
        }
    }
}