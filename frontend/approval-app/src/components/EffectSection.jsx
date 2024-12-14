import Button from "./Button/Button";
import Modal from "./Modal/Modal";
import { useState } from "react";

export default function EffectSection() {
    const [modal, setModal] = useState(false);
    const [loading, setLoading] = useState(false);

    return (
        <section>
            <h3>
                Effects
            </h3>
            <Button onClick={() => setModal(true)}>
                Открыть информацию
            </Button>
            <Modal open={modal}>
                <h3>Hello From Modal</h3>
                <p> Testing modal window.
                </p>
                <Button onClick={() => setModal(false)}>
                    Закрыть
                </Button>
            </Modal>
            
        </section>
    )
}