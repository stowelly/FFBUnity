﻿using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;

namespace Fumbbl.UI.LogText
{
    public class BlockChoice : LogTextGenerator<Ffb.Dto.Reports.BlockChoice>
    {
        public override IEnumerable<LogRecord> Convert(Ffb.Dto.Reports.BlockChoice report)
        {
            BlockDie blockResult = report.blockResult.As<BlockDie>();

            yield return new LogRecord($"<b>Block Result [ {blockResult.Name} ]</b>");

            Player attacker = FFB.Instance.Model.GetPlayer(FFB.Instance.Model.ActingPlayer.PlayerId);
            Player defender = FFB.Instance.Model.GetPlayer(report.defenderId);

            if (blockResult == BlockDie.BothDown)
            {
                if (attacker != null && attacker.HasSkill(SkillType.Block))
                {
                    yield return new LogRecord($"{attacker.FormattedName} has been saved by {attacker.Gender.Genetive} Block skill.");
                }
                if (defender != null && defender.HasSkill(SkillType.Block))
                {
                    yield return new LogRecord($"\n{defender.FormattedName} has been saved by {defender.Gender.Genetive} Block skill.");
                }
            }
            else if (blockResult == BlockDie.PowPushback)
            {
                if (defender != null && attacker != null && defender.HasSkill(SkillType.Dodge) && attacker.HasSkill(SkillType.Tackle))
                {
                    yield return new LogRecord($"\n{attacker.FormattedName} uses Tackle to bring opponent down.");
                }
            }
        }
    }
}
