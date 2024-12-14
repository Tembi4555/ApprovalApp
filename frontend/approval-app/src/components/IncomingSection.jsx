import Button from "./Button/Button";
import { differences } from "../data"
import { useState } from "react";

export default function IncomingSection() {
    const [contentType, setContentType] = useState(null);

    function handleClick(type){
        setContentType(type);
    }

    return (
        <section>
          <h3>
            Входящие
          </h3>
            <p>Входящее 1</p>
            <p>Входящее 2</p>
            <p>Входящее 3</p>
            {/* <Button 
              isActive={contentType === 'way'}
              onTouch={() => handleClick('way')}
            >
              Подход
            </Button>
            <Button 
            isActive={contentType === 'easy'}
              onTouch={() => handleClick('easy')}
            >
              Доступность
            </Button>
            <Button 
              isActive={contentType === 'program'}
              onTouch={() => handleClick('program')}
            >
              Концентрация
            </Button>

            {!contentType && <p>Нажми на кнопку</p>}
            {contentType && <p>{differences[contentType]}</p>} */}

        </section>
    )
}