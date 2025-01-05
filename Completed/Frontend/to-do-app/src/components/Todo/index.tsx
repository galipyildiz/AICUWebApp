import { useState } from "react";
import "./Todo.css";
interface TodoProps {
  content: string;
  isCompleted: boolean;
  onCheckChange: (checked: boolean) => void;
  onContentChange: (newContent: string) => void;
  onDeleteClick: () => void;
}

export const Todo: React.FC<TodoProps> = ({
  content,
  isCompleted,
  onCheckChange,
  onContentChange,
  onDeleteClick,
}) => {
  const [isEditing, setIsEditing] = useState<boolean>(false);
  const [newContent, setNewContent] = useState<string>(content);

  return (
    <div className={`todo ${isCompleted ? "completed" : ""}`}>
      <input
        type="checkbox"
        checked={isCompleted}
        onChange={(e) => onCheckChange(e.target.checked)}
      />
      {isEditing ? (
        <>
          <textarea
            value={newContent}
            onChange={(e) => setNewContent(e.target.value)}
            autoFocus
          />
          <button
            className="button"
            onClick={() => {
              setIsEditing(false);
              setNewContent(content);
            }}
          >
            İptal
          </button>
          <button
            onClick={() => {
              setIsEditing(false);
              onContentChange(newContent);
            }}
          >
            Kaydet
          </button>
        </>
      ) : (
        <span onDoubleClick={() => setIsEditing(true)}>{newContent}</span>
      )}
      <button
        onClick={() => onDeleteClick()}
        className={`${!isEditing && "button"} delete-button`}
      >
        X
      </button>
    </div>
  );
};
