import Button from "./Button/Button"

export default function TabsSection({active, onChange})
{
    return (
        <section style={{marginBottom: '1rem'}}>
            <Button 
                isActive={active === 'incoming'} 
                onClick={() => onChange('incoming')}
            >
                Входящие задачи
            </Button>
            <Button 
                isActive={active === 'outgoing'} 
                onClick={() => onChange('outgoing')}
            >
                Исходящие задачи
            </Button>
            <Button 
                isActive={active === 'feedback'} 
                onClick={() => onChange('feedback')}
            >
                Обратная связь
            </Button>
            <Button 
                isActive={active === 'effect'} 
                onClick={() => onChange('effect')}
            >
                Effect
            </Button>
        </section>
    )
}