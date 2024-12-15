import { useState } from "react";
import Header from "./components/Header/Header"
import IncomingSection from "./components/IncomingSection"
import IntroSection from "./components/IntroSection";
import OutGoingSection from "./components/OutGoingSection"
import TabsSection from "./components/TabsSection";
import FeedbackSection from "./components/FeedbackSection";
import EffectSection from "./components/EffectSection";
import Modal from "./components/Modal/Modal";
import DynamicOptionUsers from "./components/DynamicOptionUsers";
import Button from "./components/Button/Button";

function App() {
  const [tab, setTab] = useState('effect')
  const [modal, setModal] = useState(true);

  return (
    <> 
      <Header />
      <main>
        <Modal open={modal}>
          <h3>Выберите пользователя</h3>
          <DynamicOptionUsers />
          <Button onClick={() => setModal(false)}>
            Выбрать
          </Button>
        </Modal>
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
