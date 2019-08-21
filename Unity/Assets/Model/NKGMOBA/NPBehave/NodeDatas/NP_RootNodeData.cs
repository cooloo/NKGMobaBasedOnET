//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年8月21日 7:09:18
//------------------------------------------------------------

using System.Collections.Generic;
using NPBehave;
using Sirenix.OdinInspector;

namespace ETModel
{
    public class NP_RootNodeData: NP_NodeDataBase
    {
        [LabelText("根结点")]
        public Root m_Root;

        public override Node GetNPBehaveNode()
        {
            if (this.m_Root == null)
                this.m_Root = new Root();
            return this.m_Root;
        }

        public override void AutoSetNodeData(List<Node>  nextNode)
        {
            this.m_Root.mainNode = nextNode[0];
            this.m_Root.clock = SyncContext.Instance.GetClock();
            this.m_Root.blackboard = new Blackboard(this.m_Root.clock);
            this.m_Root.SetRoot(this.m_Root);
        }

    }
}