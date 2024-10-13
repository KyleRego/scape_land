import { useState } from "react";
import { styleHiddenIfNull,
        styleShownIfNotNull,
        styleFlexRow,
        styleFlexCol } from "./CssHelpers";

import OptionDto from "./dtos/OptionDto";
import PromptDto from "./dtos/PromptDto";

export default function Prompt({ text, options }: PromptDto) {

    const [selectedOption, setSelectedOption] =
                            useState<OptionDto | null>(null);

    const handleSelect = (option: OptionDto) => {
        setSelectedOption(option);
    };

    const submitOption = () => {
        if (selectedOption) {
            console.log('Selected option:', selectedOption);
        }
    };

    return (
        <div>
            <div style={styleHiddenIfNull(selectedOption)}>
                <p>{text}</p>

                <div style={styleFlexCol}>
                    {options.map((option, index) => (
                        <button key={index} 
                                onClick={() => handleSelect(option)}
                        >
                            {option.text}
                        </button>
                    ))}
                </div>
            </div>

            <div style={styleShownIfNotNull(selectedOption)}>
                <p>
                    {selectedOption?.warning}
                </p>
                <div style={styleFlexRow}>
                    <button onClick={submitOption}>Continue</button>
                    <button onClick={() => setSelectedOption(null)}>Go back</button>
                </div>
            </div>

        </div>
    );
}
