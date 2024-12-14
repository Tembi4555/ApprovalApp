import { useState } from "react";
import Header from "./components/Header/Header"
import IncomingSection from "./components/IncomingSection"
import IntroSection from "./components/IntroSection";
import OutGoingSection from "./components/OutGoingSection"
import TabsSection from "./components/TabsSection";
import FeedbackSection from "./components/FeedbackSection";
import EffectSection from "./components/EffectSection";

function App() {
  const [tab, setTab] = useState('effect')

  return (
    <> 
      <Header />
      <main>
        <IntroSection />
        <TabsSection active={tab} onChange={(current) => setTab(current)} />

        {tab === 'outgoing' && 
          <OutGoingSection />}

        {tab === 'incoming' && 
        <IncomingSection />}

        {tab === 'feedback' && 
          <FeedbackSection />}

        {tab === 'effect' && 
          <EffectSection />}
      </main>
    </>
  )
}

export default App
